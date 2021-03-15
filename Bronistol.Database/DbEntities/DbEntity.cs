using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bronistol.Database.DbEntities
{
    public class DbEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }

        public DbEntity()
        {
            Created = DateTime.UtcNow;
        }
    }
}
