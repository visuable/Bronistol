using System.Collections.Generic;
using AutoMapper;
using Bronistol.Constants;
using Bronistol.Database.EntitiesDto;
using Bronistol.Models;

namespace Bronistol.Profilies
{
    public class BookingEntityDtoProfile : Profile
    {
        public BookingEntityDtoProfile()
        {
            CreateMap<BookingEntityDto, BookingEntityViewModel>()
                .ForMember(x => x.AssignedDate, y => y.MapFrom(z => z.AssignedDate))
                .ForMember(x => x.SubmitDate, y => y.MapFrom(z => z.SubmitDate))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Note, y => y.MapFrom(z => z.Note))
                .ForMember(x => x.Priority, y => y.MapFrom(x => x.Priority))
                .ForMember(x => x.Reason, y => y.MapFrom(z => z.Reason))
                .ReverseMap();
            CreateMap<DateEntityDto, DateEntityViewModel>()
                .ForMember(x => x.Date, y => y.MapFrom(z => z.Date.ToString(AutoMapperConstants.DateTimeFormat)))
                .ReverseMap();
            CreateMap<NameEntityDto, NameEntityViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.ShortName))
                .ReverseMap();
            CreateMap<NoteEntityDto, NoteEntityViewModel>()
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ReverseMap();
            CreateMap<PriorityEntityDto, PriorityEntityViewModel>()
                .ForMember(x => x.Priority, y => y.MapFrom(z => z.Priority.ToString()))
                .ReverseMap();
            CreateMap<ReasonEntityDto, ReasonEntityViewModel>()
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ReverseMap();
        }
    }
}