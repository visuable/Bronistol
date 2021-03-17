using Bronistol.Database.EntitiesDto;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
