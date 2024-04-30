using FoodToOrderWPFApp.Controls;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for DishesWindow.xaml
    /// </summary>
    public partial class DishesWindow : Window
    {
        private int custId;
        private int restId;

        public ObservableCollection<Dish> dishes;

        Cart cart = new Cart();
        int cartDetailId = 1;
        public DishesWindow()
        {
            InitializeComponent();
        }

        public DishesWindow(int custId, int restId)
        {
            InitializeComponent();
            this.custId = custId;
            this.restId = restId;
            //tb_dishId.Text = custId.ToString();
            //tb_restId.Text = restId.ToString();

            fetchDishes();

            dg_dishes.ItemsSource = dishes;

            //// Generate ListBox control for dishes
            //ListBox listBox = new ListBox();
            //listBox.ItemsSource = dishes;
            //listBox.ItemTemplate = GenerateDataTemplate();
            //listBox.SelectionChanged += (sender, e) =>
            //{
            //    // Handle dish selection if needed
            //};

            //// Add the ListBox to the window's content
            //Content = listBox;

        }

        public void fetchDishes()
        {
            try
            {
                List<Dish> dishesList= new List<Dish>();
                string connectionString = "Data Source=TJ16AA044-PC,49955;Initial Catalog=FoodToOrder_WPF_Prajith;User=sa;Password=sa@1234;TrustServerCertificate = True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand($"SELECT Id,DishName,Price FROM Dish WHERE Available = 1 AND RestaurantId = {restId}", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        dishesList.Add(new Dish
                        {
                            Id = (int)reader["Id"],
                            DishName = reader["DishName"].ToString(),
                            Price = (decimal)reader["Price"],
                            ImagePath = (int)reader["Id"] > 25 ? "pack://application:,,,/Images/default.jfif" : $"pack://application:,,,/Images/{reader["DishName"].ToString()}.jfif"
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

        private DataTemplate GenerateDataTemplate()
        {
            DataTemplate dataTemplate = new DataTemplate();

            // Create a StackPanel to hold the UI elements for each dish
            FrameworkElementFactory stackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));
            stackPanelFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);

            // Create an Image control
            FrameworkElementFactory imageFactory = new FrameworkElementFactory(typeof(Image));
            imageFactory.SetValue(Image.SourceProperty, new BitmapImage(new Uri($"pack://application:,,,/Images/{new System.Windows.Data.Binding("DishName")}.png")));
            // Set the height and width of the image
            imageFactory.SetValue(Image.HeightProperty, 100.0); // Set the height to 100
            imageFactory.SetValue(Image.WidthProperty, 100.0); // Set the width to 100

            stackPanelFactory.AppendChild(imageFactory);

            // Create a TextBlock to display the dish name
            FrameworkElementFactory dishNameTextBlockFactory = new FrameworkElementFactory(typeof(TextBlock));
            dishNameTextBlockFactory.SetBinding(TextBlock.TextProperty, new System.Windows.Data.Binding("DishName"));
            stackPanelFactory.AppendChild(dishNameTextBlockFactory);

            // Create a TextBlock to display the price
            FrameworkElementFactory priceTextBlockFactory = new FrameworkElementFactory(typeof(TextBlock));
            priceTextBlockFactory.SetBinding(TextBlock.TextProperty, new System.Windows.Data.Binding("Price"));
            stackPanelFactory.AppendChild(priceTextBlockFactory);

            // Create a TextBox for quantity control
            FrameworkElementFactory quantityTextBoxFactory = new FrameworkElementFactory(typeof(TextBox));
            quantityTextBoxFactory.SetBinding(TextBox.TextProperty, new System.Windows.Data.Binding("Quantity"));
            stackPanelFactory.AppendChild(quantityTextBoxFactory);

            dataTemplate.VisualTree = stackPanelFactory;

            return dataTemplate;
        }

        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {

            
            Button button = sender as Button;
           
           
            DataGridRow dataGridRow = FindVisualParent<DataGridRow>(button);
            
           
            Dish dish = dataGridRow.DataContext as Dish;
            

            QuantityControl quantityControl = FindVisualChild<QuantityControl>(dataGridRow);
          
            int quantity = quantityControl.Quantity;

            MessageBox.Show($"{dish.DishName} Dish added to cart");
           // MessageBox.Show($"Dish ID: {dish.Id}, Quantity: {quantity}");

            
            cart.CartDetails.Add(new CartDetail(cartDetailId++,dish.Id,quantity,(double)dish.Price,dish.DishName, (double)dish.Price * quantity));
            cart.Amount += (double)dish.Price * quantity;
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

        public static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            cart.UserId = custId;
            BillWindow billWindow = new BillWindow(restId, cart);
            billWindow.Show();
            Close();
        }

        private void SortBtn_Click(object sender, RoutedEventArgs e)
        {
            string columnName = "Price";
            SortDataGrid(dg_dishes, columnName);
        }

        private void SortDataGrid(DataGrid dataGrid, string columnName)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);
            if (view != null)
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription(columnName, ListSortDirection.Ascending));
                view.Refresh();
            }
        }
    }
}
