using AutoMapper;
using Bronistol.Models;

namespace Bronistol.Profilies
{
    public class BookingEntityViewModelProfile : Profile
    {
        public BookingEntityViewModelProfile()
        {
            CreateMap<BookingEntityPageModel, BookingEntityViewModel>()
                .ForPath(x => x.Name.Name, y => y.MapFrom(z => z.Name))
                .ForPath(x => x.AssignedDate.Date, y => y.MapFrom(z => z.AssignedDate))
                .ForPath(x => x.SubmitDate.Date, y => y.MapFrom(z => z.SubmitDate))
                .ForPath(x => x.Note.Description, y => y.MapFrom(z => z.Note))
                .ForPath(x => x.Reason.Description, y => y.MapFrom(z => z.Reason))
                .ForPath(x => x.Priority.Priority, y => y.MapFrom(z => z.Priority));
        }
    }
}