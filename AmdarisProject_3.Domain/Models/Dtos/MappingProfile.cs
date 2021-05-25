using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmdarisProject_3.Domain.Models.Dtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
                //It is redundant
                //.ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName))
                //.ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName));

            CreateMap<UserDto, User>();
        }
    }
}
