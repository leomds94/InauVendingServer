using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InauVendingServer.Models
{
    public partial class Maintenance {

        public Maintenance()
        {
            this.MachineMaintenances = new List<MachineMaintenance>();
        }

        [Key]
        public short MaintenanceId { get; set; }

        [DisplayName("Tipo")]
        public string MaintenanceType { get; set; }

        public List<MachineMaintenance> MachineMaintenances { get; set; }
    }
}
