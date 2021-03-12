using System;
using System.Collections.Generic;
using System.Text;

namespace Bronistol.Database.DbEntities
{
    public class DateEntity : DbEntity
    {
        public DateTime Date { get; set; }
        public string ShortDate { get; set; }
        public string DisplayDate { get; set; }
    }
}
