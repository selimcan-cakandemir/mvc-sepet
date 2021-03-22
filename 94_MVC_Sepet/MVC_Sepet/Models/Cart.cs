using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Sepet.Models
{
    public class Cart
    {

        //Dictionary is a type of list that takes two values
        Dictionary<int, CartItem> _myCart = new Dictionary<int, CartItem>();


        public List<CartItem> myCart
        {
            get
            {
                return _myCart.Values.ToList();
            }
        } 
        //Adding item
        public void AddItem(CartItem cartItem)
        {
            //Checking if item exists in the dictionary cart already
            if (_myCart.ContainsKey(cartItem.ID))
            {
                //increases the quantity of that item that exists in the cart already
                _myCart[cartItem.ID].Quantity += cartItem.Quantity;
                return;//exits the method entirely
            }
            //if not add item ID and the item tiself
            _myCart.Add(cartItem.ID, cartItem);
        }

        public void DeleteItem(CartItem cartItem)
        {
            if (_myCart.ContainsKey(cartItem.ID))
            {
                _myCart.Remove(cartItem.ID);
                return;
            }
        }




    }
}