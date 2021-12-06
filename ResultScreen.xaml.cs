using System;
using System.Collections.Generic;
using System.Linq;
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

        public ResultScreen()
        {
            InitializeComponent();
        }

        private void LoadSearchScreenButton_Click(object sender, RoutedEventArgs e)
        {
            SearchScreen search = new SearchScreen();
            search.Show();
            this.Close();
           
        }
        private void LoadMovieTitles(List<Movie> movieList)
        {
            for (int i = 1; i < 16; i++)
            {
                string movieTextBox = "TextBlock" + i;
                TextBox tb = new TextBox();
                tb.Name = movieTextBox;
                tb.Text = movieList[i].Title;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBlock1_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show("HELPPP");
           
        }

        //Loads the Movie Info Screen 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MovieInfo mi = new MovieInfo();
            mi.Show();
            this.Close();
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
    }
}
