using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Sepet.Models
{
    public class CartItem
    {
        //so that there is at least one item when instanced
        //? means it can be null
        public CartItem()
        {
            Quantity = 1;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public short Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }

        public decimal? SubTotal
        {
            get
            {
                return Quantity * UnitPrice;
            }
        }
    }
}