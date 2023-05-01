using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMVCUI.Models.ShoppingTools
{
    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short Amount { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }


        public decimal SubTotal
        {
            get
            {
                return Price * Amount;
            }
        }
        public CartItem() 
        {
            Amount++;
        }
    }
}