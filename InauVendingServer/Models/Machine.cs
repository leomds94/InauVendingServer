using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InauVendingServer.Models
{
    public partial class Machine {

        public Machine()
        {
            this.ProductMachines = new List<ProductMachine>();
            this.MachineSpots = new List<MachineSpot>();
            this.Maintenances = new List<MachineMaintenance>();
        }

        [Key]
        public int MachineId { get; set; }

        [DisplayName("Nome")]
        public string MachineName { get; set; }

        [DisplayName("Endereço")]
        public string MachineAddress { get; set; }

        [DisplayName("Fabricante")]
        public string MachineManufacturer { get; set; }

        [DisplayName("Modelo")]
        public string MachineModel { get; set; }

        [DisplayName("Tipo")]
        public string MachineType { get; set; }

        [DisplayName("Dimensões")]
        public string MachineDimension { get; set; }

        [DisplayName("Voltagem")]
        public string MachineVoltage { get; set; }

        [DisplayName("Proprietário")]
        public short OwnerId { get; set; }

        [DisplayName("Nome do Produto")]
        public List<ProductMachine> ProductMachines { get; set; }

        [DisplayName("Proprietário")]
        public Owner Owner { get; set; }

        [DisplayName("Locais da Máquina")]
        public List<MachineSpot> MachineSpots { get; set; }

        [DisplayName("Manutenções")]
        public List<MachineMaintenance> Maintenances { get; set; }
    }
}
