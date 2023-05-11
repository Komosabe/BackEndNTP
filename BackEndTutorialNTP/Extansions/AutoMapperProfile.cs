using AutoMapper;
using BackEndTutorialNTP.Entities;
using BackEndTutorialNTP.Models.FamilyMember;
using BackEndTutorialNTP.Models.Group;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Net;

namespace BackEndTutorialNTP.Extansions
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateRequestFamilyMember, FamilyMember>();
            CreateMap<UpdateRequestFamilyMember, FamilyMember>();

            CreateMap<UpdateRequestGroup, Group>();
            CreateMap<CreateRequestGroup, Group>();
        }
    }
}
