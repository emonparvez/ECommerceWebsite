using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Models
{
    public class CustomerOrder
    {

        [Key]
        public int Id { get; set; }

        public long CartId { get; set; }

        public double TotalPrice { get; set; }


        public virtual User Customer { get; set; }

        [ForeignKey("OrderStatus")]
        public int OrderStatusId { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }
    }
}