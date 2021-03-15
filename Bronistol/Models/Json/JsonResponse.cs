using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bronistol.Models.Json
{
    public class JsonResponse<T>
    {
        public T Item { get; set; }
        public DateTime ResponseTime { get; set; }
        public JsonResponse()
        {
            ResponseTime = DateTime.UtcNow;
        }
    }
}
