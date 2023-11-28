using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSystem.Shared
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set;}
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty;

        public ServiceResponse(T? data, bool success, string message)
        {
            Data = data;
            Success = success;
            Message = message;
        }
        public ServiceResponse()
        {

        }

        public ServiceResponse(T? data,string message)
        {
            Data = data;
            Success = true;
            Message = message;
        }
    }
}
