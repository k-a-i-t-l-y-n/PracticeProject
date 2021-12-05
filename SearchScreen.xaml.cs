﻿using System;
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
        string SearchGenre { get; set; }
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
            SearchGenre = (string) (GenreDropDown.SelectedItem);
        }

        //Get User input for Director 
        private void TextBox_TextChanged_4(object sender, TextChangedEventArgs e)
        {
            SearchDirector = TBDirector.Text;
        }
        
        //
        private void Get_List_Click(object sender, RoutedEventArgs e)
        {
            
            //call backend function to get MovieList
            
            //NoResultsScreen noResults = new NoResultsScreen();
            //noResults.Show();

            //this.Close();
            //MessageBox.Show("HELP ME!");
            ////if it returns results, go to ResultScreen

            if (tester == 0)
            {
                tester = 1;

                ResultScreen result = new ResultScreen();
                result.Show();

                this.Close();
            }
            else
            {
                //if it return no results, go to NoResultsScreen
                tester = 0;

                NoResultsScreen noResults = new NoResultsScreen();
                noResults.Show();

                this.Close();
                }
            }

        //exit the application
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
