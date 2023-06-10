using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Models.ViewModel
{
    public class CartViewModel
    {
        public List<Product> Products { get; set; }
        public List<double> Quantities { get; set; }

        public long UserId { get; set; }

    }
}