using ECommerceWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ECommerceWebsite.Controllers.API
{
    public class LoginController : ApiController
    {

        enum eUserTyes
        {
            Admin = 4,
            Customer = 5,
            DeliveryMan = 6
        }

        MyDbContext DbContext;

        public LoginController()
        {
            DbContext = new MyDbContext();
        }

        [HttpPost]
        public User UserLogin(User user)
        {
            var validUser = DbContext.Users.SingleOrDefault(a => a.PhoneNumber == user.PhoneNumber && a.Password == user.Password && a.UserTypeId == (int)eUserTyes.Admin);

            if (validUser != null)
            {
                return validUser;
            }
            return null;
        }
    }
}
