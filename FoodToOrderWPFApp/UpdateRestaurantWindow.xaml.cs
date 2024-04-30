using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    public partial class UpdateRestaurantWindow : Window
    {

        public ObservableCollection<Restaurant> restaurants;
        public ObservableCollection<Dish> dishes;

        Restaurant rest;
        Dish clickedDish;

        private string connectionString = "Data Source=TJ16AA044-PC,49955;Initial Catalog=FoodToOrder_WPF_Prajith;User=sa;Password=sa@1234;TrustServerCertificate = True;";
        public UpdateRestaurantWindow()
        {
            InitializeComponent();
            fetchRestaurants();
            dg_rests.ItemsSource = restaurants;
        }

        private void EditRestaurantBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;



            DataGridRow dataGridRow = FindVisualParent<DataGridRow>(button);


            rest = dataGridRow.DataContext as Restaurant;

            fetchDishes();

            grid_updRestDet.Visibility = Visibility.Visible;

            upd_restName.Text = rest.RestaurantName;
            upd_restOpen.IsChecked = rest.Open;
            upd_userId.Text = rest.UserId.ToString();
            dg_upd_dishes.Visibility = Visibility.Visible;
            dg_upd_dishes.ItemsSource = dishes;
            btn_wantToAddDishDet.Visibility = Visibility.Visible;
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

       

        private void updRestDet_Click(object sender, RoutedEventArgs e)
        {
            string query = $"UPDATE Restaurants SET RestaurantName = '{upd_restName.Text}', [Open] = '{upd_restOpen.IsChecked}',UserId = '{upd_userId.Text}' WHERE Id = {rest.Id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show($"{rest.RestaurantName} restaurant is updated");
                    fetchRestaurants();
                    dg_rests.ItemsSource = restaurants;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating data: " + ex.Message);
                }
            }
        }

        private void UpdateDishBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;


            DataGridRow dataGridRow = FindVisualParent<DataGridRow>(button);


            clickedDish = dataGridRow.DataContext as Dish;

            grid_updDishDet.Visibility = Visibility.Visible;
            upd_dishName.Text = clickedDish.DishName;
            upd_dishAvl.IsChecked = clickedDish.Available;
            upd_dishPrice.Text = clickedDish.Price.ToString();
        }

        private void DeleteDishBtn_Click(object sender, RoutedEventArgs e)
        {

           
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this dish?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // Check the user's response
            if (result == MessageBoxResult.Yes)
            {
                // User clicked Yes, proceed with deletion
                Button button = sender as Button;


                DataGridRow dataGridRow = FindVisualParent<DataGridRow>(button);


                Dish delDish = dataGridRow.DataContext as Dish;
                DeleteDish(delDish.Id);
            }
            else
            {
                // User clicked No or closed the dialog, do nothing
            }
        }

        private void DeleteDish(int id)
        {
           
           

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"DELETE FROM Dish WHERE Id = {id}";

                SqlCommand command = new SqlCommand(query, connection);
                

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        
                        Dish dishToDelete = dishes.FirstOrDefault(d => d.Id == id);

                        dishes.Remove(dishToDelete);
                        MessageBox.Show($"{dishToDelete.DishName} dish is deleted");
                        // Refresh the DataGrid to reflect the changes
                        dg_upd_dishes.Items.Refresh();
                    }
                    else
                    {
                        MessageBox.Show($"No dish found ");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting dish: " + ex.Message);
                }
            }

        }

        private void updDishDet_Click(object sender, RoutedEventArgs e)
        {
            string query = $"UPDATE Dish SET DishName = '{upd_dishName.Text}', [Available] = '{upd_dishAvl.IsChecked}',Price = '{upd_dishPrice.Text}' WHERE Id = {clickedDish.Id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    

                    Dish dishToUpdate = dishes.FirstOrDefault(d => d.Id == clickedDish.Id);

                    // Update the properties of the dish
                    if (dishToUpdate != null)
                    {
                        dishToUpdate.DishName = upd_dishName.Text;
                        dishToUpdate.Available = (bool)upd_dishAvl.IsChecked; // Set available status
                        dishToUpdate.Price = Decimal.Parse(upd_dishPrice.Text); // Set new price
                    }
                    MessageBox.Show($"{clickedDish.DishName} dish is updated");
                    // Refresh the DataGrid to reflect the changes
                    dg_upd_dishes.Items.Refresh();

                   grid_updDishDet.Visibility = Visibility.Collapsed;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating data: " + ex.Message);
                }
            }
        }

       

        private void wantToAddDishDet_Click(object sender, RoutedEventArgs e)
        {
            grid_addDishDet.Visibility = Visibility.Visible;
            btn_wantToAddDishDet.Visibility = Visibility.Collapsed;
        }

        private void addDishDet_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Dish (DishName, Available, Price, RestaurantId) VALUES (@DishName, @Available, @Price, @RestaurantId)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DishName", add_dishName.Text);
                command.Parameters.AddWithValue("@Available", add_dishAvl.IsChecked);
                command.Parameters.AddWithValue("@Price", add_dishPrice.Text);
                command.Parameters.AddWithValue("@RestaurantId", rest.Id);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Successfully added new dish");
                        fetchDishes();
                        dg_upd_dishes.ItemsSource = dishes;
                        grid_addDishDet.Visibility = Visibility.Collapsed;
                        btn_wantToAddDishDet.Visibility = Visibility.Visible;
                        grid_updDishDet.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        MessageBox.Show("Failed to add new dish");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding new dish: " + ex.Message);
                }
            }
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

