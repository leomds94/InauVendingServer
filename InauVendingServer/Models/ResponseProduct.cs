using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InauVendingServer.Models
{
    public class ResponseProduct
    {
        public ResponseProduct(List<EntityReleaseProduct> data, bool success)
        {
            this.data = data;
            this.success = success;
        }

        public List<EntityReleaseProduct> data { get; set; }
        public bool success { get; set; }
    }
}
