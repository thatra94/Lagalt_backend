using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.ResponseModel
{
    public class CommonResponse<T>
    {
        public T Data { get; set; }
        public Error Error { get; set; }
    }
    public class Error
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
