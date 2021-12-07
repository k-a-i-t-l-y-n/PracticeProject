using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PracticeProject
{
    /// <summary>
    /// Interaction logic for ResultScreen.xaml
    /// </summary>
    public partial class ResultScreen : Window
    {

        //SearchScreen search = new SearchScreen();
        private const int movieCount = 15; //This the number of movies to load
        private int movieIndex; //This holds the index position of the movie object in the movie list

        //list of movie objects
        IList<Movie> movies;
        //ResultScreen result = new ResultScreen();


        //MovieInfo Window object to be 
        //loaded if the user clicks on a movie

        MovieInfo mi;
        List<Movie> movieTitles = new List<Movie>();

        public ResultScreen()
        {
            
        }
        public ResultScreen(MovieList movieList)
        {
            InitializeComponent();
            
            //Gets movie List from backend
            movieTitles = movieList.getMovieList();
            
            //Loads the titles of the movies
            LoadMovieTitles(movieTitles);
        }

        private void LoadSearchScreenButton_Click(object sender, RoutedEventArgs e)
        {
            SearchScreen search = new SearchScreen();
            search.Show();
            this.Close();
           
        }
        private void LoadMovieTitles(List<Movie> movieList)
        {
            if (movieList.Count != 0)
            {
                for (int i = 1; i < movieList.Count; i++)
                {
                    if (i < 16)
                    {
                        string movieTextBox = "TextBlock" + i;
                        TextBox tb = Canvas.FindName(movieTextBox) as TextBox;
                        //tb.Name = movieTextBox;
                        //Controls.Add(tb);
                        //Trace.WriteLine(movieList[i-1].MovieID);
                        //MessageBox.Show(tb.Name + " " + movieList[i - 1].Title);
                        tb.Text = movieList[i - 1].Title;
                    }

                }
            }
        }

        //Exits application
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //DELETE
        private void TextBlock1_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show("HELPPP");
           
        }

        //Gets more information about the chosen movie
        //Loads the Movie Info Screen 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Query query = new Query();
            InfoMovie infoMovie = new InfoMovie();

            if (button.Name == "Button1")
            {
                //calls query to get movie information based on the movie title
                infoMovie = query.getMoreMovieInfoQuery(TextBlock1.Text);

                //loads new MovieInfo Screen
                MovieInfo mi = new MovieInfo(infoMovie, this);

                mi.Show();
               // this.Close();
            }
            if (button.Name == "Button2")
            {
                //calls query to get movie information based on the movie title
                infoMovie = query.getMoreMovieInfoQuery(TextBlock2.Text);

                //loads new MovieInfo Screen
                MovieInfo mi = new MovieInfo(infoMovie, this);

                mi.Show();
                //this.Close();
            }
            if (button.Name == "Button3")
            {
                //calls query to get movie information based on the movie title
                infoMovie = query.getMoreMovieInfoQuery(TextBlock3.Text);

                //loads new MovieInfo Screen
                MovieInfo mi = new MovieInfo(infoMovie, this);

                mi.Show();
                //this.Close();
            }
            if (button.Name == "Button4")
            {
                //calls query to get movie information based on the movie title
                infoMovie = query.getMoreMovieInfoQuery(TextBlock4.Text);

                //loads new MovieInfo Screen
                MovieInfo mi = new MovieInfo(infoMovie, this);

                mi.Show();
             //   this.Close();
            }
            if (button.Name == "Button5")
            {
                //calls query to get movie information based on the movie title
                infoMovie = query.getMoreMovieInfoQuery(TextBlock5.Text);

                //loads new MovieInfo Screen
                MovieInfo mi = new MovieInfo(infoMovie, this);

                mi.Show();
               // this.Close();
            }
            if (button.Name == "Button6")
            {
                //calls query to get movie information based on the movie title
                infoMovie = query.getMoreMovieInfoQuery(TextBlock6.Text);

                //loads new MovieInfo Screen
                MovieInfo mi = new MovieInfo(infoMovie, this);

                mi.Show();
               // this.Close();
            }
            if (button.Name == "Button7")
            {
                //calls query to get movie information based on the movie title
                infoMovie = query.getMoreMovieInfoQuery(TextBlock7.Text);

                //loads new MovieInfo Screen
                MovieInfo mi = new MovieInfo(infoMovie, this);

                mi.Show();
               // this.Close();
            }
            if (button.Name == "Button8")
            {
                //calls query to get movie information based on the movie title
                infoMovie = query.getMoreMovieInfoQuery(TextBlock8.Text);

                //loads new MovieInfo Screen
                MovieInfo mi = new MovieInfo(infoMovie, this);

                mi.Show();
               // this.Close();
            }
            if (button.Name == "Button9")
            {
                //calls query to get movie information based on the movie title
                infoMovie = query.getMoreMovieInfoQuery(TextBlock9.Text);

                //loads new MovieInfo Screen
                MovieInfo mi = new MovieInfo(infoMovie, this);

                mi.Show();
              //  this.Close();
            }
            if (button.Name == "Button10")
            {
                //calls query to get movie information based on the movie title
                infoMovie = query.getMoreMovieInfoQuery(TextBlock10.Text);

                //loads new MovieInfo Screen
                MovieInfo mi = new MovieInfo(infoMovie, this);

                mi.Show();
               // this.Close();
            }
            if (button.Name == "Button11")
            {
                //calls query to get movie information based on the movie title
                infoMovie = query.getMoreMovieInfoQuery(TextBlock11.Text);

                //loads new MovieInfo Screen
                MovieInfo mi = new MovieInfo(infoMovie, this);

                mi.Show();
               // this.Close();
            }
            if (button.Name == "Button12")
            {
                //calls query to get movie information based on the movie title
                infoMovie = query.getMoreMovieInfoQuery(TextBlock12.Text);

                //loads new MovieInfo Screen
                MovieInfo mi = new MovieInfo(infoMovie, this);

                mi.Show();
               // this.Close();
            }
            if (button.Name == "Button13")
            {
                //calls query to get movie information based on the movie title
                infoMovie = query.getMoreMovieInfoQuery(TextBlock13.Text);

                //loads new MovieInfo Screen
                MovieInfo mi = new MovieInfo(infoMovie, this);

                mi.Show();
               // this.Close();
            }
            if (button.Name == "Button14")
            {
                //calls query to get movie information based on the movie title
                infoMovie = query.getMoreMovieInfoQuery(TextBlock14.Text);

                //loads new MovieInfo Screen
                MovieInfo mi = new MovieInfo(infoMovie, this);

                mi.Show();
               // this.Close();
            }
            if (button.Name == "Button15")
            {
                //calls query to get movie information based on the movie title
                infoMovie = query.getMoreMovieInfoQuery(TextBlock15.Text);

                //loads new MovieInfo Screen
                MovieInfo mi = new MovieInfo(infoMovie, this);

                mi.Show();
                //this.Close();
            }

        }

        private void LoadNewMoviesButton_Click(object sender, RoutedEventArgs e)
        {
            //mi = new MovieInfo(this);
            LoadNewMovieList(this.movies);
        }

        private void LoadPreviousMoviesButton_Click(object sender, RoutedEventArgs e)
        {
            // mi = new MovieInfo(this);
            LoadPreviousMovieList(this.movies);
        }
        
        private void LoadPreviousMovieList(IList<Movie> movieList)
        {
            TextBox tb = new TextBox();
            //string tbName = "";
            int tbCounter = 15;//used to automate displays the textboxes
            int i = 0;

            for (i = (movieIndex - 15); i >= (movieIndex - 15); i--)
            {
                tb.Name = "TextBox" + tbCounter;
                tb.Text = movieList.ElementAt(i).Title;
                tbCounter--;
            }
            movieIndex = 0;
        }
        private void LoadNewMovieList(IList<Movie> movieList)
        {

            TextBox tb = new TextBox();
            string tbName = "";
            int tbCounter = 1;
            int i = 0;
            for (i = movieIndex; i < movieCount; i++)
            {
                tb.Name = "TextBox" + tbCounter;
                tb.Text = movieList.ElementAt(i).Title;
                tbCounter++;
            }
            movieIndex = i;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LoadScreen load = new LoadScreen();
            load.Show();
            //this.Close();
        }
    }
}
