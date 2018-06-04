using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InauVendingServer.Models
{
    public partial class ProductMachine {

        public ProductMachine()
        {
            this.ProductOrders = new List<ProductOrder>();
            this.Supplies = new List<Supply>();
        }

        [Key]
        public int ProductMachineId { get; set; }

        [DisplayName("Quantidade disponível")]
        public int ProductMachineQty { get; set; }

        [DisplayName("Produto")]
        public int ProductId { get; set; }

        [DisplayName("Máquina")]
        public int MachineId { get; set; }

        [DisplayName("Preço")]
        public decimal ProductMachinePrice { get; set; }

        [DisplayName("Nome do Produto")]
        public Product Product { get; set; }

        [DisplayName("Nome da Máquina")]
        public Machine Machine { get; set; }

        [DisplayName("Produto da Nota")]
        public List<ProductOrder> ProductOrders { get; set; }

        [DisplayName("Nome do Produto")]
        public List<Supply> Supplies { get; set; }

        [DisplayName("Posição do Produto")]
        public int ProductMachineIndex { get; set; }
    }

}
