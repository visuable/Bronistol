using AutoMapper;

using Bronistol.Database.DbEntities;
using Bronistol.Models.EntitiesDto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bronistol.Profilies
{
    public class BookingEntityProfile : Profile
    {
        public BookingEntityProfile()
        {
            CreateMap<BookingEntityDto, BookingEntity>()
                .ForMember(x => x.Reason, y => y.MapFrom(z => z.Reason))
                .ForMember(x => x.Note, y => y.MapFrom(z => z.Note))
                .ForMember(x => x.Priority, y => y.MapFrom(z => z.Priority))
                .ForMember(x => x.SubmitDate, y => y.MapFrom(z => z.SubmitDate))
                .ForMember(x => x.AssignedDate, y => y.MapFrom(z => z.AssignedDate));
            CreateMap<ReasonEntityDto, ReasonEntity>()
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description));
            CreateMap<NoteEntityDto, NoteEntity>()
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description));
            CreateMap<PriorityEntityDto, PriorityEntity>()
                .ForMember(x => x.Priority, y => y.MapFrom(z => z.Priority));
            CreateMap<NameEntityDto, NameEntity>()
                .ForMember(x => x.ShortName, y => y.MapFrom(z => z.ShortName))
                .ForMember(x => x.FullName, y => y.MapFrom(z => z.FullName))
                .ForMember(x => x.OrganizationName, y => y.MapFrom(z => z.OrganizationName));
            CreateMap<DateEntityDto, DateEntity>()
                .ForMember(x => x.ShortDate, y => y.MapFrom(z => z.ShortDate))
                .ForMember(x => x.DisplayDate, y => y.MapFrom(z => z.DisplayDate))
                .AfterMap((x, y) => y.Date = DateTime.Parse(x.ShortDate));
        }
    }
}
