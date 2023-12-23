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
            CreateMap<Doctor, DoctorListViewModel>().ReverseMap();
            CreateMap<Doctor, DoctorDuzenleViewModel>().ReverseMap();
            CreateMap<Admin, AdminListViewModel>().ReverseMap();
            CreateMap<Poliklinik, PoliklinikListViewModel>().ReverseMap();
        }
    }
}