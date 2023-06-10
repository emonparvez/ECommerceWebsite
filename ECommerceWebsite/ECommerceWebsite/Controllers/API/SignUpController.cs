using ECommerceWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ECommerceWebsite.Controllers.API
{
    public class SignUpController : ApiController
    {
        MyDbContext DbContext;

        public SignUpController()
        {
            DbContext = new MyDbContext();
        }

        [HttpPost]
        public User UserSignUp(User user)
        {
            var existingUser = DbContext.Users.Where(a => a.PhoneNumber == user.PhoneNumber);

            if (existingUser.Any())
            {
                return null;
            }

            DbContext.Users.Add(user);
            DbContext.SaveChanges();

            return user;
        }

    }
}
