using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bronistol.Options.Validations
{
    public class GetReservedTablesCommandValidatorOptions : ValidationOptions
    {
        public int MaxCount { get; set; }
    }
}
