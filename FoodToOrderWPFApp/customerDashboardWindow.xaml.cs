using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for customerDashboardWindow.xaml
    /// </summary>
    public partial class customerDashboardWindow : Window
    {
       private int custId;
        public ObservableCollection<Restaurant> restaurants;
        public string selectedName { get; set; }

        public customerDashboardWindow()
        {
            InitializeComponent();
            this.custId = 0;
            fetchRestaurants();

            restList.ItemsSource = restaurants;
        }

        public customerDashboardWindow(int custId)
        {
            InitializeComponent();
           this.custId = custId;
            fetchRestaurants();

            restList.ItemsSource = restaurants;


        }

        
        public void fetchRestaurants()
        {
            List<Restaurant> rests = new List<Restaurant>();
            string connectionString = "Data Source=TJ16AA044-PC,49955;Initial Catalog=FoodToOrder_WPF_Prajith;User=sa;Password=sa@1234;TrustServerCertificate = True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                SqlCommand command = new SqlCommand("SELECT Id,RestaurantName FROM Restaurants WHERE [Open] = 1", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    rests.Add(new Restaurant
                    {
                        Id = (int)reader["Id"],
                        RestaurantName = reader["RestaurantName"].ToString(),

                    });
                }
            }
            restaurants = new ObservableCollection<Restaurant>(rests as List<Restaurant>);
            //using (FoodToOrderWpfPrajithContext db = new())
            //{

            //    List<Restaurant> rests = db.Restaurants.ToList<Restaurant>();
            //    restaurants = new ObservableCollection<Restaurant>(rests as List<Restaurant>);
            //    MessageBox.Show(restaurants[0].RestaurantName);
            //}
        }

        private void vd_buttonClick(object sender, RoutedEventArgs e)
        {
            Restaurant selectedRest = (sender as Button).DataContext as Restaurant;
            //MessageBox.Show(custId.ToString());
            //MessageBox.Show(selectedRest.Id.ToString());
            DishesWindow dw = new(custId,selectedRest.Id);
            
            dw.Show();
            
        }
    }
}
