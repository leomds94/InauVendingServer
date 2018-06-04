using System.Collections.Generic;

namespace InauVendingServer.Models.Commands
{
    public class Response
    {
        public Response(object data, bool success)
        {
            this.data = data;
            this.success = success;
        }

        public object data { get; set; }

        public bool success { get; set; }
    }
}
