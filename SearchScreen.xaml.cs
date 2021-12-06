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
    /// Interaction logic for SearchScreen.xaml
    /// </summary>
    public partial class SearchScreen : Window
    {

        string SearchTitle { get; set; }
        string SearchDirector { get; set; }
        string SearchYear { get; set; }
        List<string> SearchGenre { get; set; }
        public List<string> GenreCollection { get; set; }

        int tester;

        public SearchScreen()
        {
            InitializeComponent();

            GenreCollection = new List<string> {       
                "Action", "Drama","Horror", "Christmas", 
                "Thriller","Comedy","Science Fiction","Romance",
                " Western","Adventure", "Fiction","Muscical",
                "Crime film","Fantasy","War","Television","Epic",
                "Historical Fiction", "Gangster","Documentary","Noir",
                "Children's Film", "Sports","Maritial Arts"};

            DataContext = this;
            tester = 0;
        }

        //Get User input for Director 
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            SearchTitle = TBTitle.Text; 
        }


        //Get User input for Year 
        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            SearchYear = TBYear.Text;
        }
        
        //Get Genre from dropdown menu
        private void Genre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItem = (string) (GenreDropDown.SelectedItem);
            SearchGenre.Add(selectedItem);
        }

        //Get User input for Director 
        private void TextBox_TextChanged_4(object sender, TextChangedEventArgs e)
        {
            SearchDirector = TBDirector.Text;
        }

        //
        private void Get_List_Click(object sender, RoutedEventArgs e)
        {

            Survey survey = new Survey();
            survey.Show();
            this.Close();
        }

        public void getUserInput()
        {
            UserInput userInput = new UserInput();
            if (SearchTitle != "")
            {
                userInput.Title = SearchTitle;
            }
            if (SearchDirector != "")
            {
                userInput.Director = SearchDirector;
            }
            if (SearchGenre != null)
            {
                userInput.Genre = SearchGenre;
            }
            if (SearchYear != "")
            {
                userInput.Year = SearchYear;
            }
        }
        //exit the application
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
