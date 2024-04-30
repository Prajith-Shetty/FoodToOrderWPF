using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrderWPFApp
{
    public class CartDetail
    {
        private int cartDetailId;

        public int CartDetailId
        {
            get { return cartDetailId; }
            set { cartDetailId = value; }
        }

        private int dishId;

        public int DishId
        {
            get { return dishId; }
            set { dishId = value; }
        }
        
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private string dishName;

        public string DishName { get => dishName; set => dishName = value; }



        private double price;

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        private double amount;

        public double Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }


        public CartDetail() { }
        public CartDetail(int cartdetailId, int dishId, int quantity,double price, string dishname, double amount)
        {
            CartDetailId = cartdetailId;
            DishId = dishId;
            Quantity = quantity;
            Price = price;
            DishName = dishname;
            Amount = amount;
        }

      
    }
}
