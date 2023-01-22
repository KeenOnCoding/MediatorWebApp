using AutoMapper;

namespace MediatorWebApp.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserView, User>(MemberList.Source);
            CreateMap<User, UserView>(MemberList.Destination);

            //CreateMap<MediatorWebApp.Core., MediatorWebApp.Core.>(MemberList.Destination);
        }
    }
}