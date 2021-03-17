using AutoMapper;

using Bronistol.Database;
using Bronistol.Database.DbEntities;
using Bronistol.Database.EntitiesDto;
using Bronistol.Database.Repositories;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bronistol.Core.Supports
{
    public class BookingSupport : IBookingSupport
    {
        private IRepository<BookingEntity> _bookingEntityRepository;
        private IMapper _mapper;

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
            var bookingEntitiesDto = new List<BookingEntityDto>();
            foreach(var bookingEntity in bookingEntities)
            {
                bookingEntitiesDto.Add(_mapper.Map<BookingEntityDto>(bookingEntity));
            }
            return bookingEntitiesDto;
        }

        public async Task UpdateBookingEntity(BookingEntityDto bookingEntityDto)
        {
            var bookingEntity = _mapper.Map<BookingEntity>(bookingEntityDto);
            await _bookingEntityRepository.UpdateAsync(bookingEntity);
        }

        public async Task RemoveBookingEntity(BookingEntityDto bookingEntityDto)
        {
            //I will add an extension. 
            await _bookingEntityRepository.RemoveAsync(x => x.Name.ShortName == bookingEntityDto.Name.ShortName);
        }
    }
}
