using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace FoodToOrderWPFApp
{
    public delegate void CalculateAmountHandler();
    public class Cart
    {
        private int id;
        public int Id 
        { 
            get { return id; } 
            set { id = value; }
        }

        private double amount;

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private List<CartDetail> cartDetails = new List<CartDetail>();
        public List<CartDetail> CartDetails
        {
            get
            {
                return cartDetails;
            }
            set
            {
                
                cartDetails = value;
               
                
            }
        }



        public Cart() {
            Amount = 0.0;
        }
        public Cart(int id, double amount, int userId) 
        { 
            Id = id;
            Amount = amount;
            UserId = userId;
        }


        
        
    }
}
