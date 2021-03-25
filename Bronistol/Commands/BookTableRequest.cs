using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bronistol.Database.EntitiesDto;
using Bronistol.Database.Enumerations;
using Bronistol.Models;
using Bronistol.Models.Responses;
using MediatR;

namespace Bronistol.Commands
{
    public class BookTableRequest : IRequest<DefaultResponse>
    {
        public BookingEntityViewModel Table { get; set; }
    }
}
