using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InauVendingServer.Models
{
    public class PendingCommand
    {
        [Key]
        public int PendingId { get; set; }

        public int status { get; set; }

        public int ProductMachineId { get; set; }

        public ProductMachine ProductMachine { get; set; }
    }
}
