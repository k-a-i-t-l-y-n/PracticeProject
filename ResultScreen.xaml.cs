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
            MessageBox.Show("HElp meeeee!");
        }

        private void LoadNewMovieList(IList<Movie> movieList)
        {
            TextBox tb = new TextBox();
            string tbName = "";
            int tbCounter = 15;//used to automate displays the textboxes
            int i = 0;
           
            for (i = (movieIndex - 15); i >  (movieIndex -15); i--)
            {
                tb.Name = "TextBox" + tbCounter;
                tb.Text = movieList.ElementAt(i).Title;
                tbCounter--;
            }
            movieIndex = 0;
        }
        private void LoadPreviousMovieList(IList<Movie> movieList)
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

        private void TextBlock1_TextChanged(object sender, TextChangedEventArgs e)
        { 
            this.Close();
            mi = new MovieInfo();
            mi.Show();
        }

        private void TextBlock2_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Close();
            mi.Show();

        }

        private void TextBlock3_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Close();
            mi = new MovieInfo();
            mi.Show();
        }

        private void TextBlock4_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Close();
            mi = new MovieInfo();
            mi.Show();
        }

        private void TextBlock5_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Close();
            mi = new MovieInfo();
            mi.Show();
        }

        private void TextBlock6_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Close();
            mi = new MovieInfo();
            mi.Show();
        }

        private void TextBlock7_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Close();
            mi = new MovieInfo();
            mi.Show();
        }

        private void TextBlock8_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Close();
            mi = new MovieInfo();
            mi.Show();
        }

        private void TextBlock9_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Close();
            mi = new MovieInfo();
            mi.Show();
        }

        private void TextBlock10_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Close();
            mi = new MovieInfo();
            mi.Show();
        }

        private void TextBlock11_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Close();
            mi = new MovieInfo();
            mi.Show();
        }

        private void TextBlock12_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Close();
            mi = new MovieInfo();
            mi.Show();
        }

        private void TextBlock13_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Close();
            mi = new MovieInfo();
            mi.Show();
        }

        private void TextBlock14_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Close();
            mi = new MovieInfo();
            mi.Show();
        }

        private void TextBlock15_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Close();
            mi = new MovieInfo();
            mi.Show();
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
    }
}
