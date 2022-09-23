using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Common
{
    public class Response : IResponse
    {
        public string Message { get; set; }
        public bool Status { get; set; }

        public Response(bool status)
        {
            Status = status;
        }

        public Response(string message, bool status)
        {
            Message = message;
            Status = status;
        }
    }
}
