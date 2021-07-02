using AutoMapper;
using ClassJournal.Dto.Users;
using ClassJournal.Web.Models.Users;

namespace ClassJournal.Web.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RoleDto, RoleModel>();
            CreateMap<UserDto, UserModel>();
            CreateMap<AdminDto, AdminModel>()
                .ForMember(model => model.Role, expression => expression.MapFrom(dto => dto.Role.Name));
        }
    }
}