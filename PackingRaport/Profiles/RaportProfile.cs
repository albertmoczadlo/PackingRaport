using AutoMapper;
using PackingRaport.Domain.Models;
using PackingRaport.ViewModels;

namespace PackingRaport.Profiles
{
    public class RaportProfile : Profile
    {
        public RaportProfile()
        {
            CreateMap<Raport, RaportViewModel>().ReverseMap();
        }
    }
}
