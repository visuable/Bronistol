using Bronistol.Core.Services.BookingService;
using Bronistol.Models.Json;
using Bronistol.Models.EntitiesDto;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bronistol.Database.DbEntities;

namespace Bronistol.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BronistolController : ControllerBase
    {
        private IBookingService _bookingService;
        private IMapper _mapper;
        public BronistolController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }
        [HttpPost]
        [Route(nameof(Book))]
        public async Task<IActionResult> Book(JsonRequest<BookingEntityDto> request)
        {
            var bookingEntity = _mapper.Map<BookingEntity>(request.Item);
            await _bookingService.Add(bookingEntity);
            return Ok(new JsonResponse<bool>() { Item = true });
        }
    }
}
