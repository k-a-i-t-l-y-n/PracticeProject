using System;
using System.IO;
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
        List<string> movies = new List<string> { "Movie1", "Movie2" , "Movie3" , "Movie4" , "Movie5" , "Movie6", "Movie7" , 
            "Movie8" , "Movie9" , "Movie10" , "Movie11" , "Movie12" , "Movie13" , "Movie14" , "Movie15" };

        public Survey()
        {
            InitializeComponent();
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
            for(int i = 1; i < 16; i++) {
                string movieTextBox = "MovieTextBox" + i;
                TextBox tb = new TextBox();
                tb.Name = movieTextBox;
                tb.Text = movieTitles[i];
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
            
            for (int i = 0; i < 15; i++)
            {
                string userInfo = surveyResults[i].userId + "," + surveyResults[i].getTitle() + "," + surveyResults[i].getRank();

                File.AppendAllText(dataPath, userInfo);
            }
        }


        //Loads the LoadScreen for Help Information
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadScreen load = new LoadScreen();
            load.Show();
            this.Close();
        }

        //Loads the results of the movie list
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ResultScreen result = new ResultScreen();
            result.Show();
            this.Close();
            NoResultsScreen noResults = new NoResultsScreen();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SearchScreen search = new SearchScreen();
            this.Close();
        }
    }
}
