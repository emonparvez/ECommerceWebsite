using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Models
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }
        public String Type { get; set; }
    }
}