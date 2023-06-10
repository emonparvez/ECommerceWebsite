using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Display(Name = "Selling Price")]
        public double SellingPrice { get; set; }


        [ForeignKey("SubCatagory")]
        public int? SubCatagoryId { get; set; }

        [Display(Name = "Sub Catagory")]
        public virtual SubCatagory SubCatagory { get; set; }

        public double Quantity { get; set; }

        [ForeignKey("QuantityType")]
        public int? QuantityTypeId { get; set; }

        public virtual QuantityType QuantityType { get; set; } // KG, Litter, MiliLitter, Poa, Hali



    }
}