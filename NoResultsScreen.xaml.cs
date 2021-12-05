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
    /// Interaction logic for NoResultsScreen.xaml
    /// </summary>
    public partial class NoResultsScreen : Window
    {
        public NoResultsScreen()
        {
            InitializeComponent();
        }

        //This function loads the search screen after a failed movie recommendation attempt
        //and executes after the user clicks the "Try Again" function.
        private void TrySearchAgainButton_Click(object sender, RoutedEventArgs e)
        {
            //Load the Search Screen
            SearchScreen searchScreen = new SearchScreen();
            searchScreen.Show();
            this.Close();
         

        }

        //This function exits the entire application and executes after the user clicks the "Exit App" button.
        private void ExitAppButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
