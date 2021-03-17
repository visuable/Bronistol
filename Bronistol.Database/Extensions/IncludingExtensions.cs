
using Bronistol.Database.DbEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using System;
using System.Collections.Generic;
using System.Text;

namespace Bronistol.Database.Extensions
{
    public static class IncludingExtensions
    {
        public static IIncludableQueryable<BookingEntity, DbEntity> IncludeBookingEntity(this DbSet<BookingEntity> bookingEntities)
        {
            return bookingEntities
                .Include(x => x.AssignedDate)
                .Include(x => x.SubmitDate)
                .Include(x => x.Reason)
                .Include(x => x.Priority)
                .Include(x => x.Note)
                .Include(x => x.Name);
        }
    }
}
