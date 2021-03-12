using System;
using System.Collections.Generic;
using System.Text;
using Bronistol.Database.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Bronistol.Database
{
    public class BronistolContext : DbContext
    {
        public DbSet<BookingEntity> BookingEntities { get; set; }
        public DbSet<ReasonEntity> ReasonEntities { get; set; }
        public DbSet<NoteEntity> NoteEntities { get; set; }
        public DbSet<DateEntity> DateEntities { get; set; }

        public BronistolContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
    }
}
