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

namespace FoodToOrderWPFApp
{
    /// <summary>
    /// Interaction logic for RestaurantsWindow.xaml
    /// </summary>
    public partial class RestaurantsWindow : Window
    {
        public RestaurantsWindow()
        {
            InitializeComponent();
        }

        

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string str = "";
            foreach(ListBoxItem li in listRestaurants.SelectedItems)
            {
                if(li.Content is StackPanel)
                {
                    StackPanel sp = (StackPanel)li.Content;
                    TextBlock textBlock = (TextBlock)sp.Children[0];
                    str += textBlock.Text.ToString() + "\n";
                }
                else
                {
                    str += li.Content.ToString();
                }
                MessageBox.Show(str);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
