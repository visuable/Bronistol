using System;
using System.Globalization;
using AutoMapper;
using Bronistol.Database.DbEntities;
using Bronistol.Database.EntitiesDto;
using Bronistol.Options;
using Microsoft.Extensions.Options;

namespace Bronistol.Profiles
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
                .ForMember(x => x.AssignedDate, y => y.MapFrom(z => z.AssignedDate))
                .ReverseMap();
            CreateMap<ReasonEntityDto, ReasonEntity>()
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ReverseMap();
            CreateMap<NoteEntityDto, NoteEntity>()
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ReverseMap();
            CreateMap<PriorityEntityDto, PriorityEntity>()
                .ForMember(x => x.Priority, y => y.MapFrom(z => z.Priority))
                .ReverseMap();
            CreateMap<NameEntityDto, NameEntity>()
                .ForMember(x => x.ShortName, y => y.MapFrom(z => z.ShortName))
                .ForMember(x => x.FullName, y => y.MapFrom(z => z.FullName))
                .ForMember(x => x.OrganizationName, y => y.MapFrom(z => z.OrganizationName))
                .ReverseMap();
            CreateMap<DateEntityDto, DateEntity>()
                .ForMember(x => x.Date, y => y.MapFrom(z => z.Date))
                .ReverseMap();
        }
    }
}