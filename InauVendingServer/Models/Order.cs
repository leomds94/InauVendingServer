using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InauVendingServer.Models
{
    public partial class Order {

        public Order()
        {
            this.ProductOrders = new List<ProductOrder>();
        }

        [Key]
        public int OrderId { get; set; }

        public DateTime OrderTime { get; set; }

        public string OrderInvoice { get; set; }

        public string OrderStatus { get; set; }

        public decimal OrderTotalPrice { get; set; }

        public List<ProductOrder> ProductOrders { get; set; }
    }

}
