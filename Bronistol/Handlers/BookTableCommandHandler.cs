using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bronistol.Commands;
using Bronistol.Core.Supports;
using Bronistol.Database.EntitiesDto;
using Bronistol.Database.Enumerations;
using Bronistol.Models.Responses;
using Bronistol.Options;
using Bronistol.Validators;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Options;

namespace Bronistol.Handlers
{
    public class BookTableCommandHandler : IRequestHandler<Commands.BookTableRequest, DefaultResponse>
    {
        private BookTableRequestValidator _bookTableRequestValidator;
        private IBookingSupport _bookingSupport;
        private IMapper _mapper;
        public BookTableCommandHandler(BookTableRequestValidator bookTableRequestValidator, IBookingSupport bookingSupport, IMapper mapper)
        {
            _bookTableRequestValidator = bookTableRequestValidator;
            _bookingSupport = bookingSupport;
            _mapper = mapper;
        }

        public async Task<DefaultResponse> Handle(Commands.BookTableRequest request, CancellationToken cancellationToken)
        {
            var result = await _bookTableRequestValidator.ValidateAsync(request, CancellationToken.None);
            if (!result.IsValid) return new DefaultResponse() {Response = false};
            await _bookingSupport.AddBookingEntity(_mapper.Map<BookingEntityDto>(request.Table));
            return new DefaultResponse() {Response = true};

        }
    }
}
