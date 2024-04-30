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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoodToOrderWPFApp.Controls
{
    /// <summary>
    /// Interaction logic for QuantityControl.xaml
    /// </summary>
    public partial class QuantityControl : UserControl
    {
        public QuantityControl()
        {
            InitializeComponent();
            Quantity = 0;
        }



        public int Quantity
        {
            get { return (int)GetValue(QuantityProperty); }
            set { SetValue(QuantityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Quantity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty QuantityProperty =
            DependencyProperty.Register("Quantity", typeof(int), typeof(QuantityControl), new PropertyMetadata(0, ValueChanged));

        private static void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as QuantityControl;
            control.qty_tb.Text = e.NewValue.ToString();

        }

        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (Quantity >= 1)
            {
                Quantity--;
            }
        }

        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            Quantity++;
        }

    }
}
