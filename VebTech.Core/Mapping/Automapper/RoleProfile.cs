using AutoMapper;
using VebTech.Data.Entities;
using VebTech.Model.Response;

namespace VebTech.Core.Mapping.Automapper
{
    public class RoleProfile : Profile
    {
        public RoleProfile() 
        {
            CreateMap<Role, RoleResponseModel>();
        }
    }
}
