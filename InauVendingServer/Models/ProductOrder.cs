using System.ComponentModel.DataAnnotations;

namespace InauVendingServer.Models
{
    public partial class ProductOrder {

        [Key]
        public int ProductMachineId { get; set; }

        [Key]
        public int OrderId { get; set; }

        public short ProductOrderQty { get; set; }

        public ProductMachine ProductMachine { get; set; }

        public Order Order { get; set; }
    }

}