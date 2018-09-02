using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DccyOrigination.Models
{
    public class ResultModel
    {
        public int StateCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
