using MVC_Sepet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Sepet.Controllers
{
    public class HomeController : Controller
    {

        NORTHWNDEntities db = new NORTHWNDEntities();
        public ActionResult Index()
        {
            ViewBag.Categories = db.Categories.ToList();
            return View(db.Products.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddToCart(int id)
        {
            Product eklenecek = db.Products.Find(id);

            #region First method
            //Cart c = null;

            //if (Session["cart"] == null)
            //{
            //    c = new Cart();
            //}
            //else
            //{
            //    c = Session["cart"] as Cart;
            //} 
            #endregion

            #region Second method, ternary
            //Cart creation
            //Ternary, single line if statement
            // ? means if. This statement is saying, if Session cart is null make new cart, if its not (:) make a cart then put it in Cart c
            Cart c = Session["cart"] == null ? new Cart() : Session["cart"] as Cart; 
            #endregion
            //cart item creation
            CartItem cartItem = new CartItem();
            cartItem.ID = eklenecek.ProductID;
            cartItem.UnitPrice = eklenecek.UnitPrice;
            cartItem.Name = eklenecek.ProductName;
            cartItem.UnitsInStock = eklenecek.UnitsInStock;
            //session creation
            c.AddItem(cartItem);
            Session["cart"] = c;

            return RedirectToAction("Index");
        }

        public ActionResult DeleteFromCart(int id)
        {
            Product silinecek = db.Products.Find(id);

            Cart c = Session["cart"] == null ? new Cart() : Session["cart"] as Cart;

            CartItem cartItem = new CartItem();
            cartItem.ID = silinecek.ProductID;

            c.DeleteItem(cartItem);
            Session["cart"] = c;

            return RedirectToAction("Index", "Cart");
        }
    }
}