using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Models
{
    public class Offer
    {
        public int id { get; set; }
        public int ProductId { get; set; }
        public double discountPersentage { get; set; } // If the discount is in persentage.. Else persent would be 0
        public double discountMoney { get; set; } // If the discount is in exact money.. Else it would be 0

    }
}