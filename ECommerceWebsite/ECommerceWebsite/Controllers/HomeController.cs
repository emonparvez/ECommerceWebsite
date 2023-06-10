using ECommerceWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ECommerceWebsite.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext dbContext;


        enum eUserTyes
        {
            Admin = 4,
            Customer = 5,
            DeliveryMan = 6
        }

        public HomeController()
        {
            dbContext = new MyDbContext();
        }

        public ActionResult Index()
        {
            
            return View();
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

        public ActionResult Login(User user)
        {
            if (user != null)
            {
                var foundUser = dbContext.Users.Include(a => a.UserType).FirstOrDefault(u => u.PhoneNumber == user.PhoneNumber && u.Password == user.Password);

                if (foundUser != null)
                {
                    if (foundUser.UserType.Id == (int)eUserTyes.Admin)
                    {
                        Session["loggedIn"] = "True";
                        return RedirectToAction("Index", "Admin");
                    }
                }
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session["loggedIn"] = "False";

            return RedirectToAction("Index","Home");
        }
    }
}