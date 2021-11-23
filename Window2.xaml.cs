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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public int Index { get; private set; }

        public Window2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            String Title = Console.ReadLine();
            
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            String Author = Console.ReadLine();
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            String Year = Console.ReadLine();
        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {
            String Genre = Console.ReadLine();
        }

        private void TextBox_TextChanged_4(object sender, TextChangedEventArgs e)
        {
            String Director = Console.ReadLine();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var win2= new Window3();
            win2.Show();
            this.Close(); 
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var win2 =  new Window1();
            win2. Show();
            this.Close();
        }
    }
}