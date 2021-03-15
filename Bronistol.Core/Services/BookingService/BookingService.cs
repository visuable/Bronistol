using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bronistol.Database;
using Bronistol.Database.DbEntities;

using Microsoft.EntityFrameworkCore;

namespace Bronistol.Core.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly BronistolContext _bronistolContext;

        public BookingService(BronistolContext bronistolContext)
        {
            _bronistolContext = bronistolContext;
        }

        public async Task Add(BookingEntity bookingEntity)
        {
            await _bronistolContext.BookingEntities.AddAsync(bookingEntity);
            await _bronistolContext.SaveChangesAsync();
        }

        public async Task Remove(Expression<Func<BookingEntity, bool>> predicate)
        {
            var entity = await _bronistolContext.BookingEntities.FirstOrDefaultAsync(predicate);
            if (entity is null) return;
            _bronistolContext.BookingEntities.Remove(entity);
            await _bronistolContext.SaveChangesAsync();
        }

        public async Task<BookingEntity> Get(Expression<Func<BookingEntity, bool>> predicate)
        {
            var entity = await _bronistolContext.BookingEntities.FirstOrDefaultAsync(predicate);
            return entity;
        }
    }
}
