namespace NetflixApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lstMovies = new System.Windows.Forms.ListBox();
            this.txtMovieID = new System.Windows.Forms.TextBox();
            this.txtMovieRating = new System.Windows.Forms.TextBox();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtUserOccupation = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lstMovieReviews = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.lstUserReviews = new System.Windows.Forms.ListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.topNMovies = new System.Windows.Forms.TextBox();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(12, 470);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(1218, 20);
            this.txtDatabase.TabIndex = 5;
            this.txtDatabase.Text = "netflix-200k.mdf";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 41);
            this.button1.TabIndex = 6;
            this.button1.Text = "Movies";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstMovies
            // 
            this.lstMovies.FormattingEnabled = true;
            this.lstMovies.Location = new System.Drawing.Point(179, 12);
            this.lstMovies.Name = "lstMovies";
            this.lstMovies.Size = new System.Drawing.Size(267, 212);
            this.lstMovies.TabIndex = 7;
            this.lstMovies.SelectedIndexChanged += new System.EventHandler(this.lstMovies_SelectedIndexChanged);
            // 
            // txtMovieID
            // 
            this.txtMovieID.Location = new System.Drawing.Point(470, 33);
            this.txtMovieID.Name = "txtMovieID";
            this.txtMovieID.Size = new System.Drawing.Size(100, 20);
            this.txtMovieID.TabIndex = 8;
            // 
            // txtMovieRating
            // 
            this.txtMovieRating.Location = new System.Drawing.Point(470, 87);
            this.txtMovieRating.Name = "txtMovieRating";
            this.txtMovieRating.Size = new System.Drawing.Size(100, 20);
            this.txtMovieRating.TabIndex = 9;
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.Location = new System.Drawing.Point(822, 12);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(288, 212);
            this.lstUsers.TabIndex = 10;
            this.lstUsers.SelectedIndexChanged += new System.EventHandler(this.lstUsers_SelectedIndexChanged);
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(1130, 33);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(100, 20);
            this.txtUserID.TabIndex = 11;
            // 
            // txtUserOccupation
            // 
            this.txtUserOccupation.Location = new System.Drawing.Point(1130, 87);
            this.txtUserOccupation.Name = "txtUserOccupation";
            this.txtUserOccupation.Size = new System.Drawing.Size(100, 20);
            this.txtUserOccupation.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(661, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 40);
            this.button2.TabIndex = 13;
            this.button2.Text = "Users";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 238);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(143, 35);
            this.button3.TabIndex = 14;
            this.button3.Text = "Movie Reviews";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lstMovieReviews
            // 
            this.lstMovieReviews.FormattingEnabled = true;
            this.lstMovieReviews.Location = new System.Drawing.Point(179, 238);
            this.lstMovieReviews.Name = "lstMovieReviews";
            this.lstMovieReviews.Size = new System.Drawing.Size(267, 225);
            this.lstMovieReviews.TabIndex = 15;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(661, 239);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(137, 35);
            this.button4.TabIndex = 16;
            this.button4.Text = "User Reviews";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lstUserReviews
            // 
            this.lstUserReviews.FormattingEnabled = true;
            this.lstUserReviews.Location = new System.Drawing.Point(822, 239);
            this.lstUserReviews.Name = "lstUserReviews";
            this.lstUserReviews.Size = new System.Drawing.Size(288, 225);
            this.lstUserReviews.TabIndex = 17;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 288);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(143, 40);
            this.button5.TabIndex = 18;
            this.button5.Text = "Each Movie Rating";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 367);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(143, 44);
            this.button6.TabIndex = 19;
            this.button6.Text = "Top Movies by Average Rating";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // topNMovies
            // 
            this.topNMovies.Location = new System.Drawing.Point(12, 443);
            this.topNMovies.Name = "topNMovies";
            this.topNMovies.Size = new System.Drawing.Size(143, 20);
            this.topNMovies.TabIndex = 20;
            // 
            // txtRating
            // 
            this.txtRating.Location = new System.Drawing.Point(619, 420);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(100, 20);
            this.txtRating.TabIndex = 23;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(616, 373);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(103, 32);
            this.button7.TabIndex = 24;
            this.button7.Text = "Add Review";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(544, 423);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Enter Rating:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(509, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(480, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Average Rating";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1169, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1150, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Occupation";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 427);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Enter N number:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 502);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.txtRating);
            this.Controls.Add(this.topNMovies);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.lstUserReviews);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.lstMovieReviews);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtUserOccupation);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.lstUsers);
            this.Controls.Add(this.txtMovieRating);
            this.Controls.Add(this.txtMovieID);
            this.Controls.Add(this.lstMovies);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDatabase);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lstMovies;
        private System.Windows.Forms.TextBox txtMovieID;
        private System.Windows.Forms.TextBox txtMovieRating;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtUserOccupation;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox lstMovieReviews;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox lstUserReviews;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox topNMovies;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

