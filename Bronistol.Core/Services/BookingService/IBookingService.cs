using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bronistol.Database.DbEntities;

namespace Bronistol.Core.Services.BookingService
{
    public interface IBookingService
    {
        Task Add(BookingEntity bookingEntity);
        Task Remove(Expression<Func<BookingEntity, bool>> predicate);
        Task<BookingEntity> Get(Expression<Func<BookingEntity, bool>> predicate);
    }
}