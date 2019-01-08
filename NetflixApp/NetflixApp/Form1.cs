//
//  Netflix  Database  Application  using  N-Tier  Design.
//
//  KRISTI GJONI
//  U.  of  Illinois,  Chicago
//  CS341,  Spring  2018
//  Project  08
//


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NetflixApp
{
    public partial class Form1 : Form
    {
        //---------------------------------------------------------------------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();
        }
        //---------------------------------------------------------------------------------------------------------------------------


        //---------------------------------------------------------------------------------------------------------------------------
        //
        // Movies
        //
        private void button1_Click(object sender, EventArgs e)
        {
            string filename = this.txtDatabase.Text;

            BusinessTier.Business biztier = new BusinessTier.Business(filename);
            var listMovies = biztier.GetAllMovies();

            DataSet ds = new DataSet();

            // Display to screen
            foreach (var movie in listMovies)
            {
                string line = string.Format("{0}", movie.MovieName);
                this.lstMovies.Items.Add(line);
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------

        //---------------------------------------------------------------------------------------------------------------------------
        //
        // Movie ID and Average Rating
        //
        private void lstMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string moviename = this.txtDatabase.Text;

            this.txtMovieID.Clear();
            this.txtMovieRating.Clear();

            BusinessTier.Business biztier = new BusinessTier.Business(this.txtDatabase.Text);

            var movie = biztier.GetMovie(this.lstMovies.Text);

            if (movie == null)  // should never happen but...
            {
                MessageBox.Show("**ERROR: Movie not found?!");
                this.txtMovieID.Text = "";
                this.txtMovieRating.Text = "";
                return;
            }

            this.txtMovieID.Text = movie.MovieID.ToString();

            var details = biztier.GetMovieDetail(movie.MovieID);

            if (details == null)  // not found, should never happen, but...
            {
                this.txtMovieRating.Text = "0";
            }
            else
            {
                this.txtMovieRating.Text = details.AvgRating.ToString();
            }

        }
        //---------------------------------------------------------------------------------------------------------------------------


        //---------------------------------------------------------------------------------------------------------------------------
        //
        // All Users
        //
        private void button2_Click(object sender, EventArgs e)
        {
            string filename = this.txtDatabase.Text;

            BusinessTier.Business biztier = new BusinessTier.Business(filename);
            var listUsers = biztier.GetAllNamedUsers();

            DataSet ds = new DataSet();

            foreach (var user in listUsers)
            {
                string line = string.Format("{0}", user.UserName);
                this.lstUsers.Items.Add(line);
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------


        //---------------------------------------------------------------------------------------------------------------------------
        //
        // User ID and Occupation
        //
        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filename = this.txtDatabase.Text;

            BusinessTier.Business biztier = new BusinessTier.Business(filename);

            // Display user ID
            var user = biztier.GetNamedUser(this.lstUsers.Text);
            this.txtUserID.Text = user.UserID.ToString();

            // Display user occupation
            var details = biztier.GetUserDetail(user.UserID);

            // Check if occupation is NULL
            if (details == null)
            {
                // No reviews
                this.txtUserOccupation.Text = "Not found";
            }
            else if (details.user.Occupation.ToString() == "")
            {
                // Occupation is null, output "not found"
                this.txtUserOccupation.Text = "Not found";
            }
            else
            {
                // Occupation is not null, output occupation
                this.txtUserOccupation.Text = details.user.Occupation.ToString();
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------


        //---------------------------------------------------------------------------------------------------------------------------
        //
        // Get Movie Reviews
        //
        private void button3_Click(object sender, EventArgs e)
        {
            // Clear list box
            this.lstMovieReviews.Items.Clear();

            // Wait for user to select a movie
            if(this.lstMovies.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a movie...");
                return;
            }

            // Get movie name
            string moviename = this.lstMovies.Text;

            // If movie name is null, display "not found"
            if (moviename == null)
            {
                MessageBox.Show("Movie not found");
                return;
            }
            

            int movieId = System.Int32.Parse(this.txtMovieID.Text);

            this.lstMovieReviews.Items.Add(moviename);
            this.lstMovieReviews.Items.Add("");
            

            BusinessTier.Business biztier = new BusinessTier.Business(this.txtDatabase.Text);

            BusinessTier.MovieDetail details = biztier.GetMovieDetail(movieId);

            var reviews = details.Reviews;


            // Check for errors

            // Check if movie is not in the database
            if(this.txtMovieID.Text == "")
            {
                // Movie not found
                MessageBox.Show("Movie Not Found");
                return;
            }

            // Check if movie has no reviews
            else if (this.txtMovieRating.Text == "0")
            {
                // No reviews found, display message box
                MessageBox.Show("No Reviews Found");
                return;
            }

            // Input is correct, display user ID and rating
            else
            {
                foreach (var review in reviews)
                {
                    string line = string.Format("{0}: {1}", review.UserID, review.Rating);
                    this.lstMovieReviews.Items.Add(line);
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------


        //---------------------------------------------------------------------------------------------------------------------------
        //
        // Get User Reviews
        // 
        private void button4_Click(object sender, EventArgs e)
        {
            // Clear list box
            this.lstUserReviews.Items.Clear();

            // Wait for user to select a user
            if (this.lstUsers.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a user...");
                return;
            }

            // Get user name 
            string username = this.lstUsers.Text;

            // Check if user is not found, display error message
            if (username == null)
            {
                MessageBox.Show("User not found");
                return;
            }


            int userID = System.Int32.Parse(this.txtUserID.Text);

            this.lstUserReviews.Items.Add(username);
            this.lstUserReviews.Items.Add("");

            


            BusinessTier.Business biztier = new BusinessTier.Business(this.txtDatabase.Text);

            BusinessTier.UserDetail details = biztier.GetUserDetail(userID);

            // No reviews
            if (details == null)
            {
                MessageBox.Show("No Reviews");
                return;
            }

            var reviews = details.Reviews;

            // Display movie name and rating
            foreach (var review in reviews)
            {
                BusinessTier.Movie movie = biztier.GetMovie(review.MovieID);

                string line = string.Format("{0} -> {1}", movie.MovieName, review.Rating);
                this.lstUserReviews.Items.Add(line);
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------


        //---------------------------------------------------------------------------------------------------------------------------
        //
        // Each Rating
        //
        private void button5_Click(object sender, EventArgs e)
        {
            // Clear list box
            this.lstMovieReviews.Items.Clear();

            // Wait for user to select a movie
            if (this.lstMovies.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a movie...");
                return;
            }

            // Get movie name
            string moviename = this.lstMovies.Text;

            // Check for error, display message if movie not found
            if (moviename == null)
            {
                MessageBox.Show("Movie not found");
                return;
            }


            int movieId = System.Int32.Parse(this.txtMovieID.Text);

            this.lstMovieReviews.Items.Add(moviename);
            this.lstMovieReviews.Items.Add("");


            BusinessTier.Business biztier = new BusinessTier.Business(this.txtDatabase.Text);

            BusinessTier.MovieDetail details = biztier.GetMovieDetail(movieId);

            var reviews = details.Reviews;

            var query = from r in details.Reviews
                        group r by r.Rating into grp
                        orderby grp.Key descending
                        select new
                        {
                            Rating = grp.Key,
                            Count = grp.Count()
                        };

            // Display rating and count
            foreach(var tuple in query)
            {
                string line = string.Format("{0}: {1}",
                    tuple.Rating, tuple.Count);

                this.lstMovieReviews.Items.Add(line);
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------


        //---------------------------------------------------------------------------------------------------------------------------
        //
        // Insert Review (user selects movie and user from listbox and inputs a rating to be added)
        //
        private void button7_Click_1(object sender, EventArgs e)
        {
            // Wait for user to select a movie
            if (this.lstMovies.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a movie...");
                return;
            }

            // Get movie name
            string moviename = this.lstMovies.Text;

            // Wait for user to select a user
            if (this.lstUsers.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a user...");
                return;
            }

            // Get user
            string username = this.lstUsers.Text;

            // Wait for user to enter a rating
            if(this.txtRating.Text == "")
            {
                MessageBox.Show("Please enter a number...");
                return;
            }

            // Get rating
            int rating = System.Int32.Parse(this.txtRating.Text);

            // Rating should be between 1-5 inclusive
            if (rating < 1 || rating > 5)
            {
                // Wrong input: display error message
                MessageBox.Show("Number must be between 1-5 inclusive.");
            }
            else
            {
                // Correct input: add review

                BusinessTier.Business biztier = new BusinessTier.Business(this.txtDatabase.Text);

                var movie = biztier.GetMovie(moviename);

                var user = biztier.GetNamedUser(username);

                var rev = biztier.AddReview(movie.MovieID, user.UserID, rating);

                MessageBox.Show("Rating has been added to database");
                return;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------


        //---------------------------------------------------------------------------------------------------------------------------
        //
        // Top N-Movies by Average Rating
        //
        private void button6_Click(object sender, EventArgs e)
        {
            // Clear listbox
            this.lstMovieReviews.Items.Clear();


            // Check for no input or negative input
            if ((this.topNMovies.Text ==  "") || System.Int32.Parse(this.topNMovies.Text) <= 0)
            {
                // Display message
                MessageBox.Show("Please enter a valid number...");
                return;
            }

            // Get the number from the user input
            int N = System.Int32.Parse(this.topNMovies.Text);

            BusinessTier.Business biztier = new BusinessTier.Business(this.txtDatabase.Text);   

            var topMovies = biztier.GetTopMoviesByAvgRating(N);

            foreach (var review in topMovies)
            {
                BusinessTier.MovieDetail avg = biztier.GetMovieDetail(review.MovieID);

                string line = string.Format("{0}: {1}", review.MovieName, avg.AvgRating);
                this.lstMovieReviews.Items.Add(line);
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------
    }
}
    