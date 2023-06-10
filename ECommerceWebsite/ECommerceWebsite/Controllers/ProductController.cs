using ECommerceWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ECommerceWebsite.Controllers
{
    public class ProductController : Controller
    {
        public MyDbContext dbContext;

        public ProductController()
        {
            dbContext = new MyDbContext();
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.SubCategories = dbContext.SubCatagories.ToList();
            ViewBag.QuantityTypes = dbContext.QuantityTypes.ToList();
            return View();
        }

        public ActionResult AddProduct(Product product)
        {
            
                dbContext.Products.Add(product);
                dbContext.SaveChanges();

                return RedirectToAction("Index", "Home");
            
            
            //return View();
        }

    }
}