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
    /// Interaction logic for ViewRestaurantWindow.xaml
    /// </summary>
    public partial class ViewRestaurantWindow : Window
    {
        public ObservableCollection<Restaurant> restaurants;
        public ObservableCollection<Dish> dishes;

        Restaurant rest;
       
        private string connectionString = "Data Source=TJ16AA044-PC,49955;Initial Catalog=FoodToOrder_WPF_Prajith;User=sa;Password=sa@1234;TrustServerCertificate = True;";
        public ViewRestaurantWindow()
        {
            InitializeComponent();
            fetchRestaurants();
            dg_rests.ItemsSource = restaurants;
        }

        private void ViewRestaurantBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;



            DataGridRow dataGridRow = FindVisualParent<DataGridRow>(button);


            rest = dataGridRow.DataContext as Restaurant;

            fetchDishes();

            
            dg_view_dishes.ItemsSource = dishes;
            dg_view_dishes.Visibility = Visibility.Visible;
        }



        public static T FindVisualParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null)
                return null;

            T parent = parentObject as T;
            if (parent != null)
                return parent;
            else
                return FindVisualParent<T>(parentObject);
        }

        public void fetchRestaurants()
        {
            List<Restaurant> rests = new List<Restaurant>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT Id,RestaurantName, [Open], UserId FROM Restaurants", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    rests.Add(new Restaurant
                    {
                        Id = (int)reader["Id"],
                        RestaurantName = reader["RestaurantName"].ToString(),
                        Open = (bool)reader["Open"],
                        UserId = (int)reader["UserId"]
                    });
                }
            }
            restaurants = new ObservableCollection<Restaurant>(rests as List<Restaurant>);

        }



       
        

       
        private void fetchDishes()
        {
            try
            {
                List<Dish> dishesList = new List<Dish>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand($"SELECT Id,DishName,Price,[Available] FROM Dish WHERE RestaurantId = {rest.Id}", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        dishesList.Add(new Dish
                        {
                            Id = (int)reader["Id"],
                            DishName = reader["DishName"].ToString(),
                            Price = (decimal)reader["Price"],
                            Available = (bool)reader["Available"],
                            ImagePath = (int)reader["Id"] > 25 ? "pack://application:,,,/Images/default.jfif" : $"pack://application:,,,/Images/{reader["DishName"].ToString()}.jfif"
                            // ImagePath = $"pack://application:,,,/Images/{reader["DishName"].ToString()}.jfif"
                        });
                    }
                }
                dishes = new ObservableCollection<Dish>(dishesList as List<Dish>);

            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during the fetching of dishes
                MessageBox.Show($"Error fetching dishes: {ex.Message}");
            }
        }
    }
}
