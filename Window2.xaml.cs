
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Win2 : Window
    {



        public int Index { get; private set; }
        public object Value { get; }
       public Action<object, TextChangedEventArgs> SetValueForText1 { get; private set; }


        public Win2()
        {
            InitializeComponent();
            LoadCombo();


        }

        

        private void Button_Click(object sender, RoutedEventArgs e) //exit button
        {
            this.Close();
        }


        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e) //textbox for Author
        {


        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e) //textbox for Year
        {


        }

        private void LoadCombo()

        {
            Combo.ItemsSource = new List<string> { 
                                                       "Action", "Drama","Horror", "Christmas", "Thriller","Comedy","Science Fiction","Romance"," Western","Adventure", "Fiction",
                                                       "Muscical","Crime film","Fantasy","War","Television","Epic","Historical Fiction", "Gangster","Documentary","Noir","Children's Film",
                                                       "Sports","Maritial Arts"
                                                     };
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) //text or use dropdown box for Genre
        {
            {

                string item = Combo.SelectedItem.ToString();
                Trace.WriteLine("==== " + item);
                MessageBox.Show("Thank You");
            }
        }



        private void TextBox_TextChanged_4(object sender, TextChangedEventArgs e) //textbox for Director
        {


        }


        private void Button_Click_1(object sender, RoutedEventArgs e) //Next Button
        {

            var win2 = new Win3();
            win2.Show();
            this.Close();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //Previous Button
        {
            var win2 = new Window1();
            win2.Show();
            this.Close();
        }



        private void Try_Again_Click(object sender, RoutedEventArgs e)
        {

            Author.Clear();
            Year.Clear();
            Director.Clear();

        }



        private void Get_List_Click(object sender, RoutedEventArgs e)
        {
            string author = Author.Text.Trim();
            string year = Year.Text.Trim();
            string Genre = Director.Text.Trim();
           // UserInput newUser = new UserInput();
            //newUser.setTitle(auther);
        }

       

        
    }
}





