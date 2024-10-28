using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.Utility
{
    public class Response<T>
    {
        public Response()
        {
        }

        public Response(T data)
        {
            Success = true;
            Message = string.Empty;
            ErrorCode = Utility.ErrorCode.ERROR_0;
            Errors = null;
            Data = data;

        }

        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public string Message { get; set; }
        public string ErrorCode { get; set; }
        public T Data { get; set; }
    }
}
