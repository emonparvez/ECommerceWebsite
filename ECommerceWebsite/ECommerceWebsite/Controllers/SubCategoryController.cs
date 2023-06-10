using ECommerceWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceWebsite.Controllers
{
    public class SubCategoryController : Controller
    {
        MyDbContext dbContext;

        public SubCategoryController()
        {
            dbContext = new MyDbContext();
        }

        // GET: SubCategory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Categories = dbContext.Catagories.ToList();
            return View();
        }

        public ActionResult AddSubCategory(SubCatagory subCatagory)
        {
            if (ModelState.IsValid)
            {
                dbContext.SubCatagories.Add(subCatagory);
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}