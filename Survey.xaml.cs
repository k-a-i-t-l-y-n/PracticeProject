using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
//using System.Windows.Shapes;

namespace PracticeProject
{
    /// <summary>
    /// Interaction logic for Survey.xaml
    /// </summary>

    //class to store the name and ranking for each movie in the survey
    public class SurveyMovies {
        public string name;
        public string ranking;
        public string userId = "672";
        
        //Constructor that initializes the member fields
        public SurveyMovies()
        {
            name = "";
            ranking = "";
        }

        //Sets the title for the movie
        public void Name(string name)
        {
            this.name = name;
        }

        //Sets the ranking for the movie
        public void Ranking(string rank)
        {
            this.ranking = rank;
        }


        //Gets the title of the movie
        public string getTitle()
        {
            return this.name;
        }

        //Gets the rank of the movie
        public string getRank()
        {
            return this.ranking;
        }
    }

    public partial class Survey : Window
    {
        //List object to store the SurveyMovies objects
        List<SurveyMovies> surveyResults = new List<SurveyMovies>();
        
        Query query = new Query();
        SearchScreen search = new SearchScreen();
        private string genre = "";
        

        List<string> movies = new List<string>();

        public Survey(SearchScreen search)
        {
            InitializeComponent();
            genre = search.SearchGenre;
            movies = query.SurveyQuery(genre);
            setMovieTextBoxes(movies);
        }

        //Executed when the checkbox is checked and the boolean value is true
        //This function checks which checkbox is checked, adds the correct movie title and ranking to the SurveyMovies object, and
        //then adds the SurveyMovies object to the surveyResults list.
        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            SurveyMovies survey = new SurveyMovies();
            if (cb.Name == "MovieCheckBox1")
            {
                survey.Name(MovieTextBox1.Text);
                survey.Ranking("5");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox2")
            {
                survey.Name(MovieTextBox2.Text);
                survey.Ranking("5");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox3")
            {
                survey.Name(MovieTextBox3.Text);
                survey.Ranking("5");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox4")
            {
                survey.Name(MovieTextBox4.Text);
                survey.Ranking("5");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox5")
            {
                survey.Name(MovieTextBox5.Text);
                survey.Ranking("5");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox6")
            {
                survey.Name(MovieTextBox6.Text);
                survey.Ranking("5");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox7")
            {
                survey.Name(MovieTextBox7.Text);
                survey.Ranking("5");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox8")
            {
                survey.Name(MovieTextBox8.Text);
                survey.Ranking("5");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox9")
            {
                survey.Name(MovieTextBox9.Text);
                survey.Ranking("5");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox10")
            {
                survey.Name(MovieTextBox10.Text);
                survey.Ranking("5");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox11")
            {
                survey.Name(MovieTextBox11.Text);
                survey.Ranking("5");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox12")
            {
                survey.Name(MovieTextBox12.Text);
                survey.Ranking("5");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox13")
            {
                survey.Name(MovieTextBox13.Text);
                survey.Ranking("5");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox14")
            {
                survey.Name(MovieTextBox14.Text);
                survey.Ranking("5");
                surveyResults.Add(survey);
            }
            else
            {
                survey.Name(MovieTextBox15.Text);
                survey.Ranking("5");
                surveyResults.Add(survey);
            }

        }

        //Executed when the checkbox is unchecked and the boolean value is false.
        //This function checks which checkbox is checked, adds the correct movie title and ranking to the SurveyMovies object, and
        //then adds the SurveyMovies object to the surveyResults list.
        private void HandleUnchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            SurveyMovies survey = new SurveyMovies();
            if (cb.Name == "MovieCheckBox1")
            {
                survey.Name(MovieTextBox1.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox2")
            {
                survey.Name(MovieTextBox2.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox3")
            {
                survey.Name(MovieTextBox3.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox4")
            {
                survey.Name(MovieTextBox4.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox5")
            {
                survey.Name(MovieTextBox5.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox6")
            {
                survey.Name(MovieTextBox6.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox7")
            {
                survey.Name(MovieTextBox7.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox8")
            {
                survey.Name(MovieTextBox8.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox9")
            {
                survey.Name(MovieTextBox9.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox10")
            {
                survey.Name(MovieTextBox10.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox11")
            {
                survey.Name(MovieTextBox11.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox12")
            {
                survey.Name(MovieTextBox12.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox13")
            {
                survey.Name(MovieTextBox13.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox14")
            {
                survey.Name(MovieTextBox14.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else
            {
                survey.Name(MovieTextBox15.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }

        }

        //Executed when the checkbox is considered null
        //This function checks which checkbox is checked, adds the correct movie title and ranking to the SurveyMovies object, and
        //then adds the SurveyMovies object to the surveyResults list.
        private void HandleThirdState(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            SurveyMovies survey = new SurveyMovies();
            if (cb.Name == "MovieCheckBox1")
            {
                survey.Name(MovieTextBox1.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox2")
            {
                survey.Name(MovieTextBox2.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox3")
            {
                survey.Name(MovieTextBox3.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox4")
            {
                survey.Name(MovieTextBox4.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox5")
            {
                survey.Name(MovieTextBox5.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox6")
            {
                survey.Name(MovieTextBox6.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox7")
            {
                survey.Name(MovieTextBox7.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox8")
            {
                survey.Name(MovieTextBox8.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox9")
            {
                survey.Name(MovieTextBox9.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox10")
            {
                survey.Name(MovieTextBox10.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox11")
            {
                survey.Name(MovieTextBox11.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox12")
            {
                survey.Name(MovieTextBox12.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox13")
            {
                survey.Name(MovieTextBox13.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox14")
            {
                survey.Name(MovieTextBox14.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
            else
            {
                survey.Name(MovieTextBox15.Text);
                survey.Ranking("1");
                surveyResults.Add(survey);
            }
        }

        //This function sets the text for each TextBox to the appropriate movie title
        //It expects a string list of movie titles
        public void setMovieTextBoxes(List<string> movieTitles)
        {
            for(int i = 1; i <= movieTitles.Count(); i++) {
                string movieTextBox = "MovieTextBox" + i;
                TextBlock tb = Grid.FindName(movieTextBox) as TextBlock;
                //tb.Name = movieTextBox;
                //Controls.Add(tb);
                tb.Text = movieTitles[i-1];

            }
          

        }
        
        //This returns a list of SurveyMovies objects that hold a movieTitle and ranking for that movie
        public List<SurveyMovies> getSurveyResults()
        {
            return this.surveyResults;
        }


        //This will add the user's reviews onto the csv file for the AI to use to train
        public void addSurveyResults()
        {
            var dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "ratings_small.csv");
            Query query = new Query();
            int movieId = 0;

            for (int i = 0; i < surveyResults.Count(); i++)
            {
                movieId = query.getMovieId(surveyResults[i].getTitle());
                string userInfo = surveyResults[i].userId + "," + movieId + "," + surveyResults[i].getRank() + "\n";

                File.AppendAllText(dataPath, userInfo);
            }
        }


        //Loads the LoadScreen for Help Information
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadScreen load = new LoadScreen();
            load.Show();
            //this.Close();
        }

        //Loads the results of the movie list
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Backend backend = new Backend();
            MovieList movieList = new MovieList();
            addSurveyResults();
            movieList = backend.GetMovieList(search.getUserInput());

            if (movieList.getMovieList().Count() == 0)
            {
                NoResultsScreen noResults = new NoResultsScreen();
                noResults.Show();
                this.Close();
            }
            else
            {
                ResultScreen result = new ResultScreen(movieList);
                result.Show();
                this.Close();
            }
    
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SearchScreen search = new SearchScreen();
            this.Close();
        }
    }
}
