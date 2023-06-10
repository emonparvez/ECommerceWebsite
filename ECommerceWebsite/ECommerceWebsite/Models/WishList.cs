using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Models
{
    public class WishList
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public List<Product> Products { get; set; }
        public DateTime UpdatedOn { get; set; }

    }
}