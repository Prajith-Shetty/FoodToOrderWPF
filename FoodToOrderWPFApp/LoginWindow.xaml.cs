using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private string email;
        private string password;
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            email = txtEmail.Text;
            password = txtPwd.Password ;
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email cannot be empty.");
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password cannot be empty.");
                txtPwd.Focus();
                return;
            }

            using (FoodToOrderWpfPrajithContext db = new())
            {
                string role = "", fName=" ", lName=" ";
                int id=0;
                bool verified = false;
                List<User> users = db.Users.ToList<User>();
                foreach (User user in users)
                {
                    if (user.Email == email && user.Password == password)
                    {
                        id = user.Id;
                        role = user.Role;
                        fName = user.FirstName;
                        lName = user.LastName;
                        verified = true;
                        
                        MessageBox.Show("Login success!!!");

                    }


                }
                if (!verified)
                {
                    MessageBox.Show("Check your username and password");
                    return;
                }

                if (role == "admin")
                {
                    adminDashboardWindow ad = new(id);
                    ad.adminName.Text = fName + " " + lName;
                    ad.Show();
                    Close();
                }
                else if(role == "customer")
                {
                    customerDashboardWindow cust = new(id);
                    cust.custName.Text = fName + " " + lName;
                    
                    cust.Show();
                    Close();
                }
            }

            //SqlConnection con = new SqlConnection("Data Source=TJ16AA044-PC,49955;Initial Catalog=FoodToOrder_WPF_Prajith;User=sa;Password=sa@1234;TrustServerCertificate = True;");
            //con.Open();
            //SqlCommand cmd = new SqlCommand("Select * from Users where Email='" + email + "'  and Password='" + password + "'", con);
            //cmd.CommandType = CommandType.Text;
            //SqlDataAdapter adapter = new SqlDataAdapter();
            //adapter.SelectCommand = cmd;
            //DataSet dataSet = new DataSet();
            //adapter.Fill(dataSet);
            //if (dataSet.Tables[0].Rows.Count > 0)
            //{
            //    string username = dataSet.Tables[0].Rows[0]["FirstName"].ToString() + " " + dataSet.Tables[0].Rows[0]["LastName"].ToString();
            //    adminDashboardWindow adminWindow = new();
            //    adminWindow.TextBlock1.Text = username;//Sending value from one form to another form.  
            //    adminWindow.Show();
            //    Close();
            //}
            //else
            //{
            //    MessageBox.Show("Sorry! Please enter existing emailid/password.");

            //}
            //con.Close();
        }

        private void txtEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                string email = textBox.Text;
                if (!IsValidEmail(email))
                {
                    ToolTip tooltip = new ToolTip();
                    tooltip.Content = "Invalid email address. Please enter a valid email.";
                    tooltip.StaysOpen = true; // Tooltip stays open until explicitly closed
                   
                    textBox.ToolTip = tooltip;
                    textBox.BorderBrush = Brushes.Red;
                    textBox.BorderThickness = new Thickness(0, 0 ,0 ,1);

                  //  textBox.Focus();

                    //textBox.Focus();
                }
                else
                {
                    // Clear the tooltip and restore default border settings if the email is valid
                    textBox.ClearValue(ToolTipProperty);
                    textBox.ClearValue(BorderBrushProperty);
                   // textBox.ClearValue(BorderThicknessProperty);
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            //// Regular expression pattern for basic email validation
            //string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            //// Check if the email matches the pattern
            //return Regex.IsMatch(email, pattern);

            string pattern = @"^.*@.*\..+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
