using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Common
{
    public class Response<T> : Response, IResponse<T>
    {
        public T Data { get; set; }


        public Response(bool status) : base(status)
        {
            Status = status;
        }

        public Response(bool status, T data) : base(status)
        {
            Data = data;
        }

        

        public Response(string message, bool status) : base(message,status)
        {

        }

    }
}
