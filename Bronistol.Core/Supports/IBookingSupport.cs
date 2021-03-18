using System.Collections.Generic;
using System.Threading.Tasks;
using Bronistol.Database.EntitiesDto;

namespace Bronistol.Core.Supports
{
    public interface IBookingSupport
    {
        Task AddBookingEntity(BookingEntityDto bookingEntityDto);
        Task<List<BookingEntityDto>> GetBookingEntities();
        Task UpdateBookingEntity(BookingEntityDto bookingEntityDto);
        Task RemoveBookingEntity(BookingEntityDto bookingEntityDto);
    }
}