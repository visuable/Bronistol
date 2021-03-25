using Bronistol.Models;
using Bronistol.Models.Responses;
using MediatR;

namespace Bronistol.Commands
{
    public class BookTableRequest : IRequest<Response<bool>>
    {
        public BookingEntityViewModel Table { get; set; }
    }
}