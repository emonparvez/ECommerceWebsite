using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Models.ViewModel
{
    public class LoginViewModel
    {
        public User User { get; set; }
        public List<UserType> UserTypes { get; set; }
    }
}