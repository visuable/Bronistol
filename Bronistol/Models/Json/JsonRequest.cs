using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bronistol.Models.Json
{
    public class JsonRequest<T>
    {
        public T Item { get; set; }
        public DateTime RequestTime { get; set; }
        public JsonRequest()
        {
            RequestTime = DateTime.UtcNow;
        }
    }
}
