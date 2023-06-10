using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CustomerOrder")]
        public int CustomerOrderId { get; set; }

        public virtual CustomerOrder CustomerOrder { get; set; }

       
        public virtual User DeliveryMan { get; set; }

        public DateTime DateTime { get; set; }

    }
}