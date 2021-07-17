using AutoMapper;
using ClassJournal.Api.Models.Requests;
using ClassJournal.Api.Models.Users;
using ClassJournal.Dto.Requests;
using ClassJournal.Dto.Users;

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
            CreateMap<PagingResultDto<AdminDto>, PagingResultModel<AdminModel>>();
        }
    }
}