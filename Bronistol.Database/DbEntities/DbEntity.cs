using System;

namespace Bronistol.Database.DbEntities
{
    public class DbEntity
    {
        public DbEntity()
        {
            Created = DateTime.UtcNow;
        }

        public int Id { get; set; }
        public DateTime Created { get; set; }
    }
}