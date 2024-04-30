using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;
using Microsoft.Build.Evaluation;

namespace FoodToOrderWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                // Get the selected file's path
                string selectedImagePath = openFileDialog.FileName;

                try
                {
                    // Get the directory where the .csproj file exists
                    string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName;

                    // Specify the destination folder where you want to store the image
                    string destinationFolder = Path.Combine(projectDirectory, "../../Images");

                    string csprojFilePath = Path.Combine(projectDirectory, "../../FoodToOrderWPFApp.csproj");

                    // Create the destination folder if it doesn't exist
                    if (!Directory.Exists(destinationFolder))
                    {
                        Directory.CreateDirectory(destinationFolder);
                    }

                    // Get the file name
                    string fileName = Path.GetFileName(selectedImagePath);

                    // Combine the destination folder path with the file name to get the full destination path
                    string destinationPath = Path.Combine(destinationFolder, fileName);

                    // Copy the selected image to the destination folder
                    File.Copy(selectedImagePath, destinationPath);

                    // Set the Build Action property of the stored image file to "Resource"
                    SetBuildAction(projectDirectory, fileName);

                    Console.WriteLine("Image saved and Build Action set successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving image: " + ex.Message);
                }
            }
        }

        private void SetBuildAction(string projectDirectory, string fileName)
        {
            string csprojFilePath = Path.Combine(projectDirectory, "../../FoodToOrderWPFApp.csproj");

            try
            {
                // Load the project file
                Project project = new Project(csprojFilePath);

                // Get the item representing the image file
                ProjectItem imageItem = project.Items.FirstOrDefault(item => item.EvaluatedInclude.Equals($"Images\\{fileName}", StringComparison.OrdinalIgnoreCase));

                if (imageItem != null)
                {
                    // Set the Build Action property to "Resource"
                    imageItem.SetMetadataValue("BuildAction", "Resource");

                    // Save the changes
                    project.Save();
                }
                else
                {
                    Console.WriteLine($"Image file '{fileName}' not found in the project.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting Build Action: {ex.Message}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}