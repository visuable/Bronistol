using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bronistol.Database.DbEntities;
using Bronistol.Database.EntitiesDto;
using Bronistol.Database.Repositories;
using Bronistol.Models;
using Bronistol.Models.Responses;
using Bronistol.Requests;
using Bronistol.Validators;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bronistol.Handlers
{
    public class
        GetReservedTablesCommandRequestHandler : IRequestHandler<GetReservedTablesCommand,
            Response<List<BookingEntityViewModel>>>
    {
        private readonly IRepository<BookingEntity> _bookingEntityRepository;
        private readonly GetReservedTablesCommandValidator _getReservedTablesCommandValidator;
        private readonly IMapper _mapper;

        public GetReservedTablesCommandRequestHandler(IRepository<BookingEntity> bookingEntityRepository,
            GetReservedTablesCommandValidator getReservedTablesCommandValidator, IMapper mapper)
        {
            _bookingEntityRepository = bookingEntityRepository;
            _getReservedTablesCommandValidator = getReservedTablesCommandValidator;
            _mapper = mapper;
        }

        public async Task<Response<List<BookingEntityViewModel>>> Handle(GetReservedTablesCommand request,
            CancellationToken cancellationToken)
        {
            var validationResult = await _getReservedTablesCommandValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) throw new Exception("Request is invalid");
            var all = await _bookingEntityRepository.GetAllAsync();
            var count = request.Count + request.Offset * request.Count;
            var items = all.Take(count);
            var itemsDto = _mapper.ProjectTo<BookingEntityDto>(items);
            var itemsViewModel = _mapper.ProjectTo<BookingEntityViewModel>(itemsDto);
            return new Response<List<BookingEntityViewModel>>
            {
                Item = await itemsViewModel.ToListAsync(cancellationToken)
            };
        }
    }
}