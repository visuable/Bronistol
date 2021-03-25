using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bronistol.Models.Responses
{
    public class Response<T>
    {
        public T Item { get; set; }
    }
}
