using Bronistol.Database.DbEntities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bronistol.Database.Repositories
{
    public class BookingEntityRepository : IRepository<BookingEntity>
    {
        private BronistolContext _bronistolContext;

        public BookingEntityRepository(BronistolContext bronistolContext)
        {
            _bronistolContext = bronistolContext;
        }

        public async Task<BookingEntity> GetAsync(Expression<Func<BookingEntity, bool>> expression)
        {
            return await _bronistolContext.BookingEntities
                .Include(x => x.AssignedDate)
                .Include(x => x.SubmitDate)
                .Include(x => x.Reason)
                .Include(x => x.Priority)
                .Include(x => x.Note)
                .Include(x => x.Name).FirstOrDefaultAsync(expression);
        }

        public async Task AddAsync(BookingEntity entity)
        {
            await _bronistolContext.BookingEntities.AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(BookingEntity entity)
        {
            _bronistolContext.BookingEntities.Update(entity);
            await SaveChangesAsync();
        }

        public async Task RemoveAsync(Expression<Func<BookingEntity, bool>> expression)
        {
            var entity = await _bronistolContext.BookingEntities.FirstOrDefaultAsync(expression);
            _bronistolContext.BookingEntities.Remove(entity);
            await SaveChangesAsync();
        }
        private async Task SaveChangesAsync()
        {
            await _bronistolContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookingEntity>> GetAllAsync()
        {
            return await _bronistolContext.BookingEntities.ToListAsync();
        }

        public async Task<BookingEntity> FirstAsync()
        {
            return await _bronistolContext.BookingEntities.FirstOrDefaultAsync();
        }

        public void Dispose()
        {
            _bronistolContext.Dispose();
        }
    }
}
