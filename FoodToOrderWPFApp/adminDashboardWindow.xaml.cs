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
    /// Interaction logic for adminDashboardWindow.xaml
    /// </summary>
    public partial class adminDashboardWindow : Window
    {
        private int adminId;


        List<string> adminMenuItems = new List<string>
    {
        "1. View Restaurants",
        "2. Add a Restaurant",
        "3. Update Restaurant",
        "4. Delete Restaurant"
    };

        public adminDashboardWindow()
        {
            InitializeComponent();
            this.adminId = 1;


            adminMenuListView.ItemsSource = adminMenuItems;
        }

        public adminDashboardWindow(int adminId)
        {
            InitializeComponent();
            this.adminId = adminId;
            

            adminMenuListView.ItemsSource = adminMenuItems;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string msg = (string)button.DataContext;
            //MessageBox.Show(msg);
            int choice = int.Parse(msg.Substring(0, 1));
            switch(choice)
            {
                case 1:
                    ViewRestaurantWindow viewRestaurantWindow = new ViewRestaurantWindow();
                    viewRestaurantWindow.Show();
                    break;
                case 2:
                    AddRestaurantWindow addRestaurantWindow = new AddRestaurantWindow();
                    addRestaurantWindow.Show();
                    break;
                case 3: 
                    UpdateRestaurantWindow updateRestaurantWindow = new UpdateRestaurantWindow();
                    updateRestaurantWindow.Show();
                    break;
                case 4: 
                    DeleteRestaurantWindow deleteRestaurantWindow = new DeleteRestaurantWindow();
                    deleteRestaurantWindow.Show();
                    break;
                default: break;

            }
        }
    }
}
