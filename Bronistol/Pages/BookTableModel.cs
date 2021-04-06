using System.Threading.Tasks;
using AutoMapper;
using Bronistol.Core.Supports;
using Bronistol.Database.EntitiesDto;
using Bronistol.Models;
using Bronistol.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bronistol.Pages
{
    public class BookTableModel : PageModel
    {
        private readonly BookingEntityViewModelValidator _bookingEntityViewModelValidator;
        private readonly IBookingSupport _bookingSupport;
        private readonly IMapper _mapper;

        public BookTableModel(IBookingSupport bookingSupport,
            BookingEntityViewModelValidator bookingEntityViewModelValidator, IMapper mapper)
        {
            _bookingSupport = bookingSupport;
            _bookingEntityViewModelValidator = bookingEntityViewModelValidator;
            _mapper = mapper;
        }

        [BindProperty] public BookingEntityPageModel BookingEntityPageModel { get; set; }

        public async Task<IActionResult> OnPostSubmitAsync()
        {
            var model = _mapper.Map<BookingEntityViewModel>(BookingEntityPageModel);
            var result = await _bookingEntityViewModelValidator.ValidateAsync(model);
            if (!result.IsValid) return Content(result.ToString());
            var mappedEntity = _mapper.Map<BookingEntityDto>(model);
            await _bookingSupport.AddBookingEntity(mappedEntity);
            return Content("Стол забронирован.");
        }
    }
}