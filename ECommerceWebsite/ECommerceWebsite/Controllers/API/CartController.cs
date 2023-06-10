using ECommerceWebsite.Models;
using ECommerceWebsite.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ECommerceWebsite.Controllers.API
{
    public class CartController : ApiController
    {
        MyDbContext DbContext;

        public CartController()
        {
            DbContext = new MyDbContext();
        }

        [HttpPost]
        public Cart AddToCart(AddToCartViewModel addToCart)
        {
            var findExistingCart = DbContext.Carts.SingleOrDefault(b => b.UserId == addToCart.UserId && b.Confirm == false);

            if (findExistingCart != null) // He has existing cart so just add on it
            {
                List<Product> products = new List<Product>();
                products.Add(addToCart.product);

                findExistingCart.Products.Concat(products);
                findExistingCart.Quantities.ToList().Add(addToCart.quantity);
                findExistingCart.CartCreatedOn = DateTime.Now;
                findExistingCart.Confirm = false;

                DbContext.SaveChanges();

                return findExistingCart;
            }
            else
            {
                Cart cart = new Cart();
                List<Product> products = new List<Product>();
                List<double> quantities = new List<double>();

                cart.CartCreatedOn = DateTime.Now;
                cart.Confirm = false;

                products.Add(addToCart.product);
                quantities.Add(addToCart.quantity);

                cart.Products = products.AsQueryable();
                cart.Quantities = quantities.AsQueryable();
                cart.UserId = addToCart.UserId;

                DbContext.Carts.Add(cart);
                DbContext.SaveChanges();

                return cart;
            }
        }

        [HttpPost]
        public Cart GetCart()
        {

            return DbContext.Carts.ToList().Last();
        }



    }
}
