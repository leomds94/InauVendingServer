using System.ComponentModel;

namespace InauVendingServer.Models
{
    public partial class Supply {

        [DisplayName("Produto")]
        public int ProductMachineId { get; set; }

        [DisplayName("Abastecimento")]
        public int SupplyId { get; set; }

        [DisplayName("Quantidade")]
        public short SupplyQty { get; set; }

        public string SupplyTime { get; set; }

        [DisplayName("Produto Máquina")]
        public ProductMachine ProductMachine { get; set; }
    }
}
