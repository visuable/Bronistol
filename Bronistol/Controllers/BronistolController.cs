using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Bronistol.Core.Supports;
using Bronistol.Database.EntitiesDto;
using Bronistol.Models;
using Bronistol.Models.Json;
using Microsoft.AspNetCore.Mvc;

namespace Bronistol.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BronistolController : ControllerBase
    {
        private readonly IBookingSupport _bookingSupport;
        private IMapper _mapper;

        public BronistolController(IBookingSupport bookingSupport, IMapper mapper)
        {
            _bookingSupport = bookingSupport;
            _mapper = mapper;
        }

        [HttpPost]
        [Route(nameof(BookTable))]
        public async Task<IActionResult> BookTable(JsonRequest<BookingEntityModel> request)
        {
            var bookingEntityDto = new BookingEntityDto
            {
                Name = new NameEntityDto
                {
                    ShortName = request.Item.MeetName
                },
                Priority = new PriorityEntityDto
                {
                    Priority = request.Item.Priority
                },
                Note = new NoteEntityDto
                {
                    Description = request.Item.Note
                },
                Reason = new ReasonEntityDto
                {
                    Description = request.Item.Note
                },
                AssignedDate = new DateEntityDto
                {
                    ShortDate = request.Item.AssignedDate
                },
                SubmitDate = new DateEntityDto
                {
                    ShortDate = request.Item.SubmitDate
                }
            };
            await _bookingSupport.AddBookingEntity(bookingEntityDto);
            return Ok(new JsonResponse<bool> {Item = true});
        }

        [HttpPost]
        [Route(nameof(GetReservedTables))]
        public async Task<IActionResult> GetReservedTables(JsonRequest<object> request)
        {
            var bookingEntitiesDto = await _bookingSupport.GetBookingEntities();
            return Ok(new JsonResponse<List<BookingEntityDto>> {Item = bookingEntitiesDto});
        }

        [HttpPost]
        [Route(nameof(RemoveTable))]
        public async Task<IActionResult> RemoveTable(JsonRequest<BookingEntityRemoveModel> request)
        {
            var bookingEntityDto = new BookingEntityDto
            {
                Name = new NameEntityDto
                {
                    ShortName = request.Item.Name
                }
            };
            await _bookingSupport.RemoveBookingEntity(bookingEntityDto);
            return Ok(new JsonResponse<bool> {Item = true});
        }
    }
}