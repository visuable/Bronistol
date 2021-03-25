using System.Threading.Tasks;
using Bronistol.Database.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Bronistol.Database
{
    public class BronistolContext : DbContext
    {
        public BronistolContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public BronistolContext()
        {
        }

        public DbSet<BookingEntity> BookingEntities { get; set; }
        public DbSet<ReasonEntity> ReasonEntities { get; set; }
        public DbSet<NoteEntity> NoteEntities { get; set; }
        public DbSet<PriorityEntity> PriorityEntities { get; set; }
        public DbSet<NameEntity> NameEntities { get; set; }
        public DbSet<DateEntity> AssignedDates { get; set; }
        public DbSet<DateEntity> SubmitDates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Server = 127.0.0.1; Port = 5432; Database = bronistolDatabase; Username = bronistol; Password = 1111");
        }
    }
}