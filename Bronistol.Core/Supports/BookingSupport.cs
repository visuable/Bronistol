using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Bronistol.Core.Extensions;
using Bronistol.Database.DbEntities;
using Bronistol.Database.EntitiesDto;
using Bronistol.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bronistol.Core.Supports
{
    public class BookingSupport : IBookingSupport
    {
        private readonly IRepository<BookingEntity> _bookingEntityRepository;
        private readonly IMapper _mapper;

        public BookingSupport(IRepository<BookingEntity> bookingEntityRepository, IMapper mapper)
        {
            _bookingEntityRepository = bookingEntityRepository;
            _mapper = mapper;
        }

        public async Task AddBookingEntity(BookingEntityDto bookingEntityDto)
        {
            var bookingEntity = _mapper.Map<BookingEntity>(bookingEntityDto);
            await _bookingEntityRepository.AddAsync(bookingEntity);
        }

        public async Task<List<BookingEntityDto>> GetBookingEntities()
        {
            var bookingEntities = await _bookingEntityRepository.GetAllAsync();
            var bookingEntitiesDto = _mapper.MapList<BookingEntityDto, BookingEntity>(await bookingEntities.ToListAsync());
            return bookingEntitiesDto;
        }

        public async Task UpdateBookingEntity(BookingEntityDto bookingEntityDto)
        {
            var bookingEntity = _mapper.Map<BookingEntity>(bookingEntityDto);
            await _bookingEntityRepository.UpdateAsync(bookingEntity);
        }

        public async Task RemoveBookingEntity(BookingEntityDto bookingEntityDto)
        {
            await _bookingEntityRepository.RemoveAsync(x => x.Name.ShortName == bookingEntityDto.Name.ShortName);
        }
    }
}