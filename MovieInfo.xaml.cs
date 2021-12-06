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
    /// Interaction logic for MovieInfo.xaml
    /// </summary>
    /// 
    public class InfoMovie {
        public string Title { set; get; }
        public string Director { set; get; }
        public string Actors { set; get; }
        public string Description { set; get; }
        public string Genre { get; set; }
        public string Year { set; get; }



    }

    public partial class MovieInfo : Window
    {
        ResultScreen resultScreen = new ResultScreen();
        InfoMovie movie = new InfoMovie();

        public MovieInfo()
        {
            InitializeComponent();
            //call backend function to get movie information
            movie.Title = "Title;";
            movie.Director = "Dir;";
            movie.Actors = "Actors;";
            movie.Description = "Desc;";
            movie.Genre = "Genre";
            movie.Year = "Year;";

            
            LoadMovieScreenInfo(movie.Title, movie.Director, movie.Actors, movie.Description, movie.Genre, movie.Year);
        }

        private void TextBox_TextChanged(object sender, RoutedEventArgs e)
        { }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.resultScreen.Show();
        }

        private void LoadMovieScreenInfo(string title, string director, string actors, string description, string genre, string year)
        {
            MovieDescription.Text = description;
            MovieTitle.Text = title;
            MovieActor.Text = actors;
            MovieGenre.Text = genre;
            MovieYear.Text = year;
            MovieDirector.Text = director; 
        }
    }
}
