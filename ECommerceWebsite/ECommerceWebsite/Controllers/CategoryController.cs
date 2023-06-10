using ECommerceWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ECommerceWebsite.Controllers
{
    public class CategoryController : Controller
    {
        MyDbContext dbContext;

        public CategoryController()
        {
            dbContext = new MyDbContext();
        }

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult AddCategory(Catagory catagory)
        {
            if (catagory != null)
            {
                if (ModelState.IsValid)
                {
                    dbContext.Catagories.Add(catagory);
                    dbContext.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Category", "Create"); ;
        }

       


    }
}