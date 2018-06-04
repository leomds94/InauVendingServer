using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InauVendingServer.Models
{
    public partial class MachineSpot {

        [Key]
        public int MachineSpotId { get; set; }

        [DisplayName("Horário de Entrada")]
        public DateTime MachineSpotStartTime { get; set; }

        [DisplayName("Horário de Saída")]
        public DateTime MachineSpotEndTime { get; set; }

        [DisplayName("Nome do Local")]
        public string MachineSpotName { get; set; }

        [DisplayName("Endereço")]
        public string MachineSpotAddress { get; set; }

        [DisplayName("Máquina")]
        public int MachineId { get; set; }

        [DisplayName("Nome da Máquina")]
        public Machine Machine { get; set; }
    }
}
