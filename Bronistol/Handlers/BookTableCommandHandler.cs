using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bronistol.Commands;
using Bronistol.Core.Supports;
using Bronistol.Database.EntitiesDto;
using Bronistol.Models.Responses;
using Bronistol.Validators;
using MediatR;

namespace Bronistol.Handlers
{
    public class BookTableCommandHandler : IRequestHandler<BookTableRequest, Response<bool>>
    {
        private readonly BookingEntityViewModelValidator _bookingEntityViewModelValidator;
        private readonly IBookingSupport _bookingSupport;
        private readonly IMapper _mapper;

        public BookTableCommandHandler(BookingEntityViewModelValidator bookingEntityViewModelValidator,
            IBookingSupport bookingSupport, IMapper mapper)
        {
            _bookingEntityViewModelValidator = bookingEntityViewModelValidator;
            _bookingSupport = bookingSupport;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(BookTableRequest request, CancellationToken cancellationToken)
        {
            var result = await _bookingEntityViewModelValidator.ValidateAsync(request.Table, CancellationToken.None);
            if (!result.IsValid) return new Response<bool> {Item = false};
            await _bookingSupport.AddBookingEntity(_mapper.Map<BookingEntityDto>(request.Table));
            return new Response<bool> {Item = true};
        }
    }
}