using AutoMapper;
using BackEndTutorialNTP.Entities;
using BackEndTutorialNTP.Models.FamilyMember;
using BackEndTutorialNTP.Models.Group;
using System.Net;
using BackEndTutorialNTP.Models;
using BackEndTutorialNTP.Models.Users;

namespace BackEndTutorialNTP.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateRequestFamilyMember, FamilyMember>();
            CreateMap<UpdateRequestFamilyMember, FamilyMember>();

            CreateMap<UpdateRequestGroup, Group>();
            CreateMap<CreateRequestGroup, Group>();

            // User -> AuthenticateResponse
            CreateMap<User, AuthenticateResponse>();
            // RegisterRequest -> User
            CreateMap<RegisterRequest, User>();
            // UpdateRequest -> User
            CreateMap<UpdateRequest, User>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                ));
        }
    }
}
