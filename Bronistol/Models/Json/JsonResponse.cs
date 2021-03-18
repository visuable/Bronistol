using System;

namespace Bronistol.Models.Json
{
    public class JsonResponse<T>
    {
        public JsonResponse()
        {
            ResponseTime = DateTime.UtcNow;
        }

        public T Item { get; set; }
        public DateTime ResponseTime { get; set; }
    }
}