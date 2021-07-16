using AutoMapper;
using ClassJournal.Domain.Auth;
using ClassJournal.Dto.Requests;
using ClassJournal.Dto.Users;
using ClassJournal.Web.Models.Requests;
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
            CreateMap<RegisterAdminUserModel, RegisterAdminUserDto>();
            CreateMap<PagingDto, PagingModel>().ReverseMap();
            CreateMap<PagingResultDto<AdminDto>, PagingResultModel<Admin>>();
        }
    }
}