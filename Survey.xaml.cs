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
    /// Interaction logic for Survey.xaml
    /// </summary>

    //class to store the name and ranking for each movie in the survey
    public class SurveyMovies {
        public string name;
        public int ranking;
        
        //Constructor that initializes the member fields
        public SurveyMovies()
        {
            name = "";
            ranking = 0;
        }

        //Sets the title for the movie
        public void Name(string name)
        {
            this.name = name;
        }

        //Sets the ranking for the movie
        public void Ranking(int rank)
        {
            this.ranking = rank;
        }

        //Gets the title of the movie
        public string getTitle()
        {
            return this.name;
        }

        //Gets the rank of the movie
        public int getRank()
        {
            return this.ranking;
        }
    }

    public partial class Survey : Window
    {
        //List object to store the SurveyMovies objects
        List<SurveyMovies> surveyResults = new List<SurveyMovies>();

        public Survey()
        {
            InitializeComponent();
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
                survey.Ranking(5);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox2")
            {
                survey.Name(MovieTextBox2.Text);
                survey.Ranking(5);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox3")
            {
                survey.Name(MovieTextBox3.Text);
                survey.Ranking(5);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox4")
            {
                survey.Name(MovieTextBox4.Text);
                survey.Ranking(5);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox5")
            {
                survey.Name(MovieTextBox5.Text);
                survey.Ranking(5);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox6")
            {
                survey.Name(MovieTextBox6.Text);
                survey.Ranking(5);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox7")
            {
                survey.Name(MovieTextBox7.Text);
                survey.Ranking(5);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox8")
            {
                survey.Name(MovieTextBox8.Text);
                survey.Ranking(5);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox9")
            {
                survey.Name(MovieTextBox9.Text);
                survey.Ranking(5);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox10")
            {
                survey.Name(MovieTextBox10.Text);
                survey.Ranking(5);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox11")
            {
                survey.Name(MovieTextBox11.Text);
                survey.Ranking(5);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox12")
            {
                survey.Name(MovieTextBox12.Text);
                survey.Ranking(5);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox13")
            {
                survey.Name(MovieTextBox13.Text);
                survey.Ranking(5);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox14")
            {
                survey.Name(MovieTextBox14.Text);
                survey.Ranking(5);
                surveyResults.Add(survey);
            }
            else
            {
                survey.Name(MovieTextBox15.Text);
                survey.Ranking(5);
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
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox2")
            {
                survey.Name(MovieTextBox2.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox3")
            {
                survey.Name(MovieTextBox3.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox4")
            {
                survey.Name(MovieTextBox4.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox5")
            {
                survey.Name(MovieTextBox5.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox6")
            {
                survey.Name(MovieTextBox6.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox7")
            {
                survey.Name(MovieTextBox7.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox8")
            {
                survey.Name(MovieTextBox8.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox9")
            {
                survey.Name(MovieTextBox9.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox10")
            {
                survey.Name(MovieTextBox10.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox11")
            {
                survey.Name(MovieTextBox11.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox12")
            {
                survey.Name(MovieTextBox12.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox13")
            {
                survey.Name(MovieTextBox13.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox14")
            {
                survey.Name(MovieTextBox14.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else
            {
                survey.Name(MovieTextBox15.Text);
                survey.Ranking(0);
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
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox2")
            {
                survey.Name(MovieTextBox2.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox3")
            {
                survey.Name(MovieTextBox3.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox4")
            {
                survey.Name(MovieTextBox4.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox5")
            {
                survey.Name(MovieTextBox5.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox6")
            {
                survey.Name(MovieTextBox6.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox7")
            {
                survey.Name(MovieTextBox7.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox8")
            {
                survey.Name(MovieTextBox8.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox9")
            {
                survey.Name(MovieTextBox9.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox10")
            {
                survey.Name(MovieTextBox10.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox11")
            {
                survey.Name(MovieTextBox11.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox12")
            {
                survey.Name(MovieTextBox12.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox13")
            {
                survey.Name(MovieTextBox13.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else if (cb.Name == "MovieCheckBox14")
            {
                survey.Name(MovieTextBox14.Text);
                survey.Ranking(0);
                surveyResults.Add(survey);
            }
            else
            {
                survey.Name(MovieTextBox15.Text);
                survey.Ranking(0);
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
    }
}
