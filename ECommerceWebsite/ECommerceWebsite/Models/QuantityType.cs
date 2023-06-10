using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Models
{
    public class QuantityType
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Quantity Type")]
        public String Name { get; set; }

    }
}