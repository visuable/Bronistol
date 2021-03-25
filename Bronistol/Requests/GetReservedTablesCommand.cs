using System.Collections.Generic;
using Bronistol.Models;
using Bronistol.Models.Responses;
using MediatR;

namespace Bronistol.Requests
{
    public class GetReservedTablesCommand : IRequest<Response<List<BookingEntityViewModel>>>
    {
        public int Count { get; set; }
        public int Offset { get; set; }
    }
}
