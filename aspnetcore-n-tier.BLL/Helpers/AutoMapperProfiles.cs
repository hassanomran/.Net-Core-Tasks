using aspnetcore_n_tier.DTO.DTOs;
using aspnetcore_n_tier.Entity.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore_n_tier.DAL.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UsertDetailsDTO>().ReverseMap();
            CreateMap<User, UsertDetailsDTO>()
               .ForMember(x => x.RoleName, opt => opt.MapFrom(x => x.role.ID));
            CreateMap<User, UsertDetailsDTO>().ReverseMap();
        }
    }
}
