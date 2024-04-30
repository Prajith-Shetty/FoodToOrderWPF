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
    /// Interaction logic for DeleteRestaurantWindow.xaml
    /// </summary>
    public partial class DeleteRestaurantWindow : Window
    {
        public ObservableCollection<Restaurant> restaurants;

        Restaurant rest;

        private string connectionString = "Data Source=TJ16AA044-PC,49955;Initial Catalog=FoodToOrder_WPF_Prajith;User=sa;Password=sa@1234;TrustServerCertificate = True;";

        public DeleteRestaurantWindow()
        {
            InitializeComponent();
            fetchRestaurants();
            dg_rests.ItemsSource = restaurants;
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
        private void DelRestaurantBtn_Click(object sender, RoutedEventArgs e)
        {


            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this restaurant?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // Check the user's response
            if (result == MessageBoxResult.Yes)
            {
                Button button = sender as Button;

                DataGridRow dataGridRow = FindVisualParent<DataGridRow>(button);

                rest = dataGridRow.DataContext as Restaurant;

                DeleteRestaurant(rest.Id);
            }
            else
            {
                // User clicked No or closed the dialog, do nothing
            }
        }

        private void DeleteRestaurant(int id)
        {



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"DELETE FROM Restaurants WHERE Id = {id}";

                SqlCommand command = new SqlCommand(query, connection);


                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {

                        Restaurant restToDelete = restaurants.FirstOrDefault(r => r.Id == id);

                        restaurants.Remove(restToDelete);
                        MessageBox.Show($"{restToDelete.RestaurantName} Restaurant is deleted");
                        // Refresh the DataGrid to reflect the changes
                        dg_rests.Items.Refresh();
                    }
                    else
                    {
                        MessageBox.Show($"No Restaurant found ");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting restaurant: " + ex.Message);
                }
            }

            //deleting dishes of that particular restaurant
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Dish WHERE RestaurantId = @RestaurantId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RestaurantId", id);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Successfully deleted {rowsAffected} dishes for restaurant with ID {id}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting dishes: " + ex.Message);
                }
            }


        }
    }
}
