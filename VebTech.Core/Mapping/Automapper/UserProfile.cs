using AutoMapper;
using VebTech.Core.DTO;
using VebTech.Data.Entities;

namespace VebTech.Core.Mapping.Automapper
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
