//
//  BusinessTier:    businesslogic,  acting  as  interface  between  UI  and  data  store.
//
//  KRISTI GJONI
//  U.  of  Illinois,  Chicago
//  CS341,  Spring  2018
//  Final  Project
//

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BusinessTier
{

  //
  // Business:
  //
  public class Business
  {
    //
    // Fields:
    //
    private string _DBFile;
    private DataAccessTier.Data dataTier;


    //
    // Constructor:
    //
    public Business(string DatabaseFilename)
    {
      _DBFile = DatabaseFilename;

      dataTier = new DataAccessTier.Data(DatabaseFilename);
    }


    //
    // TestConnection:
    //
    // Returns true if we can establish a connection to the database, false if not.
    //
    public bool TestConnection()
    {
      return dataTier.TestConnection();
    }


    //
    // GetNamedUser:
    //
    // Retrieves User object based on USER NAME; returns null if user is not
    // found.
    //
    // NOTE: there are "named" users from the Users table, and anonymous users
    // that only exist in the Reviews table.  This function only looks up "named"
    // users from the Users table.
    //
    public User GetNamedUser(string UserName)
    {
            // Error handling
            UserName = UserName.Replace("'", "''");

            // SQL Query
            string SQL = string.Format(@"SELECT UserName, UserID, Occupation
                                         FROM Users
                                         WHERE UserName = '{0}';", UserName);

            // Execute Query
            var userInfo = dataTier.ExecuteScalarQuery(SQL);

            if (userInfo == null)
            {
                // SQL fails, return null
                return null;
            }
            else
            {
                User namedUser;
                int userID;

                DataSet ds = new DataSet();

                // Execute Query
                ds = dataTier.ExecuteNonScalarQuery(SQL);

                var table = ds.Tables["TABLE"];
                var row = table.Rows[0];

                // Get userID
                userID = System.Int32.Parse((row["UserID"]).ToString());

                namedUser = new User(userID, UserName, (row["Occupation"]).ToString());

                return namedUser;
            }
            
    }


    //
    // GetAllNamedUsers:
    //
    // Returns a list of all the users in the Users table ("named" users), sorted 
    // by user name.
    //
    // NOTE: the database also contains lots of "anonymous" users, which this 
    // function does not return.
    //
    public IReadOnlyList<User> GetAllNamedUsers()
    {
            // SQL Query
            string SQL = "SELECT * FROM Users ORDER BY UserName ASC";

            List<User> user_List = new List<User>();
            int userID;
            User user;

            DataSet ds = new DataSet();

            // Execute Query
            ds = dataTier.ExecuteNonScalarQuery(SQL);

            // Add to user list
            foreach (DataRow row in ds.Tables["TABLE"].Rows)
            {
                userID = System.Int32.Parse((row["UserID"]).ToString());
                user = new User(userID, (row["UserName"]).ToString(), (row["Occupation"]).ToString());
                user_List.Add(user);
            }

            return user_List;
    }


    //
    // GetMovie:
    //
    // Retrieves Movie object based on MOVIE ID; returns null if movie is not
    // found.
    //
    public Movie GetMovie(int MovieID)
    {
        // SQL Query
        string SQL = string.Format(@"SELECT MovieID 
                                     FROM Movies
                                     WHERE MovieID = '{0}'", MovieID);
            
        // Execute QUERY
        var movie_id = dataTier.ExecuteScalarQuery(SQL);

        if (movie_id == null)
        {
            return null;
        }
        else
        {
            Movie movie;

            // Execute QUERY
            string SQL2 = string.Format(@"SELECT MovieName FROM Movies 
                                          WHERE MovieID = '{0}'", MovieID);

            DataSet ds = new DataSet();

            // Execute QUERY
            ds = dataTier.ExecuteNonScalarQuery(SQL2);

            var R = ds.Tables["TABLE"].Rows[0];

            // Get moviename
            movie = new Movie(MovieID, R["MovieName"].ToString());

            return movie;
        }
            
    }


    //
    // GetMovie:
    //
    // Retrieves Movie object based on MOVIE NAME; returns null if movie is not
    // found.
    //
    public Movie GetMovie(string MovieName)
    {
            // Error handling
            MovieName = MovieName.Replace("'", "''");

            // SQL Query
            string SQL = string.Format(@"SELECT MovieName 
                                         FROM Movies
                                         WHERE MovieName = '{0}'", MovieName);

            // Execute Query
            var movie_name = dataTier.ExecuteScalarQuery(SQL);
            
            if (movie_name == null)
            {
                // SQL fails, return null
                return null;
            }
            else
            {
                Movie movie;

                // SQL Query
                string SQL2 = string.Format(@"SELECT MovieID
                                              FROM Movies 
                                              WHERE MovieName = '{0}'", MovieName);

                DataSet ds = new DataSet();

                // Execute Query
                ds = dataTier.ExecuteNonScalarQuery(SQL2);

                var R = ds.Tables["TABLE"].Rows[0];

                int id = System.Int32.Parse((R["MovieID"].ToString()));
                movie = new Movie(id, MovieName);

                return movie;
            }
            
    }


    //
    // GetAllMovies:
    //
    public IReadOnlyList<Movie> GetAllMovies()
    {
            // SQL Query
            string SQL = string.Format("SELECT MovieName, MovieID FROM Movies ORDER BY MovieName ASC;");

            DataSet ds = new DataSet();

            // Execute Query
            ds = dataTier.ExecuteNonScalarQuery(SQL);

            var table = ds.Tables["TABLE"];

            List < Movie > movie_List = new List<Movie>();
            int movieid;
            string moviename;
            Movie movie;

            // Add to movie list
            foreach (DataRow row in ds.Tables["TABLE"].Rows)
            {
                movieid = System.Int32.Parse(row["MovieID"].ToString());
                moviename = (row["Moviename"].ToString());
                movie = new Movie(movieid, moviename);
                movie_List.Add(movie);
            }

            return movie_List;

    }    



    //
    // AddReview:
    //
    // Adds review based on MOVIE ID, returning a Review object containing
    // the review, review's id, etc.  If the add failed, null is returned.
    //
    public Review AddReview(int MovieID, int UserID, int Rating)
    {
            // SQL Query
            string SQL = string.Format(@"
            INSERT INTO Reviews(MovieID, UserID, Rating) Values ('{0}','{1}','{2}');
            SELECT ReviewID = SCOPE_IDENTITY();
            ", MovieID, UserID, Rating);

            // Execute Query
            var R = dataTier.ExecuteScalarQuery(SQL);

            if (R == null)
            {
                // SQL Query fails, return null
                return null;
            }
            else
            {
                Review review;
                int review_id = System.Int32.Parse(R.ToString());
                review = new Review(review_id, MovieID, UserID, Rating);
                return review;
            }
    }


    //
    // GetMovieDetail:
    //
    // Given a MOVIE ID, returns detailed information about this movie --- all
    // the reviews, the total number of reviews, average rating, etc.  If the 
    // movie cannot be found, null is returned.
    //
    public MovieDetail GetMovieDetail(int MovieID)
    {
            // SQL Query
            string SQL = string.Format("SELECT MovieID FROM Movies WHERE MovieID = '{0}';", MovieID);

            // Execute Query
            var Q1 = dataTier.ExecuteScalarQuery(SQL);

            if(Q1 == null)
            {
                // SQL Query fails, return null
                return null;
            }
            else
            {
                List<Review> review_List = new List<Review>();
                
                // SQL Query
                string SQL2 = string.Format(@"SELECT ROUND(AVG(CAST(Rating AS float)),4) FROM Reviews
                                           Inner Join
                                           (
                                           SELECT MovieID From Movies
	                                       WHERE MovieID = '{0}'
                                           ) AS M
                                           On M.MovieID = Reviews.MovieID", MovieID);
        
                // Execute Query
                var Q2 = dataTier.ExecuteScalarQuery(SQL2);

                double avg;

                // Check if no average rating is found
                if (Q2.ToString() == "")
                {
                    // Average rating = 0
                    avg = 0;
                }
                else
                {
                    avg = Convert.ToDouble(Q2);
                }

                // SQL Query
                string SQL3 = string.Format(@"SELECT * 
                                           FROM Movies 
                                           WHERE MovieID = '{0}'", MovieID);

                // Execute Query
                var Q3 = dataTier.ExecuteNonScalarQuery(SQL3);
                var t = Q3.Tables["TABLE"].Rows[0];

                // SQL Query
                string SQL4 = string.Format(@"SELECT COUNT(ReviewID) 
                                           FROM Reviews
                                           WHERE MovieID = '{0}'", MovieID);

                // Execute Query
                var Q4 = dataTier.ExecuteScalarQuery(SQL4);
                int sum = System.Int32.Parse(Q4.ToString());

                Movie m = new Movie(MovieID, t["MovieName"].ToString());

                // SQL Query
                string SQL5 = string.Format(@"SELECT * 
                                           FROM Reviews 
                                           WHERE MovieID = {0}
                                           ORDER BY Rating DESC, UserID ASC", MovieID);

                // Execute Query
                var Q5 = dataTier.ExecuteNonScalarQuery(SQL5);

                Review R;

                // Add to list
                foreach (DataRow rowFour in Q5.Tables["TABLE"].Rows)
                {
                    int review_id = System.Int32.Parse(rowFour["ReviewID"].ToString());
                    int user_id = System.Int32.Parse(rowFour["UserID"].ToString());
                    int rating = System.Int32.Parse(rowFour["Rating"].ToString());
                    R = new Review(review_id, MovieID, user_id, rating);
                    review_List.Add(R);
                }

                MovieDetail details = new MovieDetail(m, avg, sum, review_List);

                return details;   
            }
        
                                       
    }


        //
        // GetUserDetail:
        //
        // Given a USER ID, returns detailed information about this user --- all
        // the reviews submitted by this user, the total number of reviews, average 
        // rating given, etc.  If the user cannot be found, null is returned.
        //
        public UserDetail GetUserDetail(int UserID)
        {
            // SQL Query
            string SQL = string.Format(@"SELECT UserName, UserID, Occupation 
                                         FROM Users
                                         WHERE UserID = '{0}';", UserID);

            // Execute SQL
            var Q1 = dataTier.ExecuteScalarQuery(SQL);

            if (Q1 == null)
            {
                // SQL Query fails, return null
                return null;
            }
            else
            {
                // Execute Query
                DataSet ds = dataTier.ExecuteNonScalarQuery(SQL);
                var T = ds.Tables["TABLE"].Rows[0];

                User user;

                user = new User(UserID, T["UserName"].ToString(), T["Occupation"].ToString());

                // SQL Query
                string SQL2 = string.Format(@"SELECT ROUND(AVG(Cast(Rating as float)),4) 
                                              FROM Reviews
                                              Inner Join
                                              (
                                              SELECT UserID FROM Users
	                                          WHERE UserID = '{0}'
                                              ) AS Temp
                                              ON Temp.UserID = Reviews.UserID", UserID);

                double avg = 0;

                // Execute Query
                var Q2 = dataTier.ExecuteScalarQuery(SQL2);

                if (Q2 == DBNull.Value)
                {
                    // SQL Query fails, return null
                    return null;
                }
                else
                {
                    // Convert to double
                    avg = Convert.ToDouble(Q2);
                }

                // SQL Query
                string SQL3 = string.Format(@"SELECT COUNT(ReviewID)
                                              FROM Reviews 
                                              WHERE UserID = '{0}'", UserID);

                // Execute Query
                var Q3 = dataTier.ExecuteScalarQuery(SQL3);
                int sum = 0;

                if (Q3 == null)
                {
                    // SQL Query fails, return null
                    return null;
                }
                else
                {
                    sum = System.Int32.Parse(Q3.ToString());
                }

                // SQL Query
                string SQL4 = string.Format(@"SELECT ReviewID, MovieID, UserID, Rating 
                                              FROM Reviews
                                              WHERE UserID = '{0}'
                                              ORDER BY Rating DESC", UserID);

                // Execute Query
                DataSet ds2 = dataTier.ExecuteNonScalarQuery(SQL4);

                List<Review> review_List = new List<Review>();
                Review review;
                int review_id;
                int movie_id;
                int rating;

                // Add to list
                foreach (DataRow rowTwo in ds2.Tables["TABLE"].Rows)
                {
                    review_id = System.Int32.Parse(rowTwo["ReviewID"].ToString());
                    movie_id = System.Int32.Parse(rowTwo["MovieID"].ToString());
                    rating = System.Int32.Parse(rowTwo["Rating"].ToString());
                    review = new Review(review_id, movie_id, UserID, rating);
                    review_List.Add(review);
                }

                UserDetail details;
                details = new UserDetail(user, avg, sum, review_List);
                return details;
            }
            
        }


    //
    // GetTopMoviesByAvgRating:
    //
    // Returns the top N movies in descending order by average rating.  If two
    // movies have the same rating, the movies are presented in ascending order
    // by name.  If N < 1, an EMPTY LIST is returned.
    //
    public IReadOnlyList<Movie> GetTopMoviesByAvgRating(int N)
    {
            // SQL Query
            string SQL = string.Format(@"SELECT TOP {0} Movies.MovieName, M.AVGRating, M.MovieID 
                                         FROM Movies
                                         INNER JOIN
                                         (
                                         SELECT Reviews.MovieID, Round(AVG(Cast(Reviews.Rating As Float )),4) As AVGRating 
                                         FROM Reviews
                                         GROUP BY Reviews.MovieID
                                         ) As M
                                         ON M.MovieID = Movies.MovieID
                                         ORDER BY M.AVGRating DESC, Movies.MovieName ASC;", N);

            DataSet ds = new DataSet();

            // Execute Query
            ds = dataTier.ExecuteNonScalarQuery(SQL);

            List<Movie> movie_List = new List<Movie>();
            
            // Add to movie list
            foreach (DataRow row in ds.Tables["TABLE"].Rows)
            {
                int movie_id = System.Int32.Parse((row["MovieID"]).ToString());
                Movie M = new Movie(movie_id, (row["MovieName"]).ToString());
                movie_List.Add(M);
            }

            return movie_List;
    }
  }
}
