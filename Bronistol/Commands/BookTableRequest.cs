using Bronistol.Models;
using MediatR;

namespace Bronistol.Commands
{
    public class BookTableRequest : IRequest<DefaultResponse>
    {
        public BookingEntityViewModel Table { get; set; }
    }
}