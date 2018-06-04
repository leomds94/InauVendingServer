using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InauVendingServer.Models
{
    public partial class MachineMaintenance {

        [Key]
        public int MachineMaintenanceId { get; set; }

        [DisplayName("Máquina")]
        public int MachineId { get; set; }

        [DisplayName("Manutenção")]
        public short MaintenanceId { get; set; }

        [DisplayName("Horário")]
        public DateTime MaintenanceTime { get; set; }

        [DisplayName("Custo do serviço")]
        public decimal MaintenanceCost { get; set; }

        [DisplayName("Nome da Máquina")]
        public Machine Machine { get; set; }

        [DisplayName("Tipo de Manutenção")]
        public Maintenance Maintenance { get; set; }
    }

}
