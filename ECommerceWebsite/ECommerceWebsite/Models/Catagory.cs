using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Models
{
    public class Catagory
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Catagory Name")]
        public String Name { get; set; }
    }
}