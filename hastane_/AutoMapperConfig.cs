using AutoMapper;
using hastane_.Entities;
using hastane_.Models;

namespace hastane_
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}