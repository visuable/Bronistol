using System.Collections.Generic;
using AutoMapper;

namespace Bronistol.Core.Extensions
{
    public static class AutoMapperExtensions
    {
        public static List<TOutput> MapList<TOutput, TInput>(this IMapper mapper, List<TInput> inputList)
        {
            var output = new List<TOutput>();
            foreach (var input in inputList) output.Add(mapper.Map<TOutput>(input));

            return output;
        }
    }
}