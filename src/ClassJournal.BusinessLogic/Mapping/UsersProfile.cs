using AutoMapper;
using ClassJournal.Domain.Auth;
using ClassJournal.Dto.Users;

namespace ClassJournal.BusinessLogic.Mapping
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Admin, AdminDto>().ReverseMap();
            CreateMap<RegisterAdminUserDto, Admin>()
                .ForMember(dto => dto.Role, expression => expression.Ignore());
            CreateMap<AdminParameters, AdminParametersDto>().ReverseMap();
        }
    }
}