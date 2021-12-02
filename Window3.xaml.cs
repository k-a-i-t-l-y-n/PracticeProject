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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Win3 : Window
    {
     
        public Win3()
        {
            InitializeComponent();

        }

      public int Index { get; private set; }
      public object PrintText_TextChanged_1 { get; private set; }
      public object TextBox1 { get; private set; }
      public Action<object, TextChangedEventArgs> SetValueForText1 { get; private set; }

        private void Button_Click(object sender, RoutedEventArgs e) //previous button
        {
            var win3 = new Win2();
            win3.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //exit button
        {
            this.Close();
        }

     

      


    }
}


