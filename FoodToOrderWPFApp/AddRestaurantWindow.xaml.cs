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
    /// Interaction logic for AddRestaurantWindow.xaml
    /// </summary>
    public partial class AddRestaurantWindow : Window
    {
        private ObservableCollection<Dish> dishes = new ObservableCollection<Dish>();
        private int restId;
        private string connectionString = "Data Source=TJ16AA044-PC,49955;Initial Catalog=FoodToOrder_WPF_Prajith;User=sa;Password=sa@1234;TrustServerCertificate = True;";
        public AddRestaurantWindow()
        {
            InitializeComponent();
            dg_add_dishes.ItemsSource = dishes;
        }

        private void addRestDet_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Restaurants (RestaurantName, [Open], UserId) VALUES (@RestaurantName, @Open, @UserId)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RestaurantName", add_restName.Text.ToString());
                command.Parameters.AddWithValue("@Open", add_restOpen.IsChecked);
                command.Parameters.AddWithValue("@UserId", int.Parse(add_userId.Text));


                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Successfully added new Restaurant");
                        
                        btn_wantToAddDishDet.Visibility = Visibility.Visible;
                        
                    }
                    else
                    {
                        MessageBox.Show("Failed to add new Restaurant");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding new Restaurant: " + ex.Message);
                }
            }

            fetchRestId(add_restName.Text.ToString());
            MessageBox.Show(restId.ToString());
        }

        private void fetchRestId(string restName)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id FROM Restaurants WHERE RestaurantName = @RestaurantName";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RestaurantName", restName);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        restId = Convert.ToInt32(result);
                    }
                    else
                    {
                        Console.WriteLine("Restaurant not found.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching restaurant ID: " + ex.Message);
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
                command.Parameters.AddWithValue("@RestaurantId", restId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Successfully added new dish");
                        dishes.Add(new Dish
                        {
                            DishName = add_dishName.Text,
                            Available = (bool)add_dishAvl.IsChecked,
                            Price = Decimal.Parse(add_dishPrice.Text)
                        });
                        dg_add_dishes.Visibility = Visibility.Visible;
                        dg_add_dishes.Items.Refresh();

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
    }
}
