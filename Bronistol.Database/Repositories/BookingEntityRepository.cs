using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bronistol.Database.DbEntities;
using Bronistol.Database.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Bronistol.Database.Repositories
{
    public class BookingEntityRepository : IRepository<BookingEntity>
    {
        private readonly BronistolContext _bronistolContext;

        public BookingEntityRepository(BronistolContext bronistolContext)
        {
            _bronistolContext = bronistolContext;
        }

        public async Task<BookingEntity> GetAsync(Expression<Func<BookingEntity, bool>> expression)
        {
            return await _bronistolContext.BookingEntities
                .IncludeBookingEntity()
                .FirstOrDefaultAsync(expression);
        }

        public async Task AddAsync(BookingEntity entity)
        {
            await _bronistolContext.BookingEntities.AddAsync(entity);
        }

        public async Task UpdateAsync(BookingEntity entity)
        {
            _bronistolContext.BookingEntities.Update(entity);
        }

        public async Task RemoveAsync(Expression<Func<BookingEntity, bool>> expression)
        {
            var entity = await _bronistolContext.BookingEntities.FirstOrDefaultAsync(expression);
            _bronistolContext.BookingEntities.Remove(entity);
        }

        public async Task<IQueryable<BookingEntity>> GetAllAsync()
        {
            return await Task.FromResult(_bronistolContext.BookingEntities.IncludeBookingEntity().AsQueryable());
        }

        public async Task<BookingEntity> FirstAsync()
        {
            return await _bronistolContext.BookingEntities.IncludeBookingEntity().FirstOrDefaultAsync();
        }
    }
}