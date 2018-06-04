using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InauVendingServer.Models
{
    public partial class Owner {

        public Owner()
        {
            this.Machines = new List<Machine>();
        }

        [Key]
        public short OwnerId { get; set; }

        [DisplayName("Nome")]
        public string OwnerName { get; set; }

        [DisplayName("Endereço")]
        public string OwnerAddress { get; set; }

        [DisplayName("Proprietário")]
        public List<Machine> Machines { get; set; }
    }
}
