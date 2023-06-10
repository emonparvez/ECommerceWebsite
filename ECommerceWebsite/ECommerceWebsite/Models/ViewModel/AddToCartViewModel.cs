using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Models.ViewModel
{
    public class AddToCartViewModel
    {
        public Product product { get; set; }
        public double quantity { get; set; }

        public long UserId { get; set; }
    }
}