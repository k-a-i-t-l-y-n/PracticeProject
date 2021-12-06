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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class LoadScreen : Window
    {
        public LoadScreen()
        {
            InitializeComponent();
            LoadTextBoxes();
        }

        private void LoadTextBoxes()
        {
            SurveyTB.Text = "Select the checkbox for each movie that you like. Then when you are finished selecting the movies. Select the Done button";
            SearchTB.Text = "Input the appropriate information for each field on the screen. For the Genre field, choose one of the genres from the menu. Select the get list button, once you have finished entering information.";
            ResultsTB.Text = "This screen displays the recommended movie list. Select the more button to get more information about the movie. Select Load More Movies and Load Previous Movies to go through the movie list.";
            MovieInfoTB.Text = "This screen displays more information about the movie you selected. Click the X button to exit this screen and return to the Results screen.";
        }

        private void Button_Click(object sender, RoutedEventArgs e) //exit button
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//next button
        {
            SearchScreen search = new SearchScreen();
            search.Show();
            this.Close();
            //Survey survey = new Survey();
            //survey.Show();
            //this.Close();

       
        }

        
    }
}
