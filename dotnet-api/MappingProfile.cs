using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using models;

namespace giant
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TimeSheetEntry, TimeSheetEntryDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ReverseMap();
        }
       
    }
}
