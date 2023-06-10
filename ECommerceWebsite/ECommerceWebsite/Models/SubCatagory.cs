using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Models
{
    public class SubCatagory
    {
        public int Id { get; set; }
        public String Name { get; set; }

        [ForeignKey("Catagory")]
        public int CatagoryId { get; set; }
        public Catagory Catagory { get; set; }

    }
}