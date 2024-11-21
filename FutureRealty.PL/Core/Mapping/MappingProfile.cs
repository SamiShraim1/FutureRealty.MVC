using AutoMapper;
using FutureRealty.DAL.Data.Migrations;
using FutureRealty.DAL.Models;
using FutureRealty.PL.Areas.Dashboard.ViewModels;
using FutureRealty.PL.Models;
using FutureRealty.PL.ViewModels;

namespace FutureRealty.PL.Core.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile() 
        {
            CreateMap<ServiceFormVM, Service>().ReverseMap();
            CreateMap<Service, ServicesVM>();
            CreateMap<Service, ServiceDetailsVM>();

            CreateMap<PortfolioFormVM, Portfolio>().ReverseMap();
            CreateMap<Portfolio, PortfoliosVM>();
            CreateMap<Portfolio, PortfolioDetailsVM>();


            CreateMap<ItemFormVM, Item>().ReverseMap();
            CreateMap<Item, ItemsVM>();
            CreateMap<Item, ItemDetailsVM>();

            CreateMap<OurTeamFormVM, OurTeam>().ReverseMap();
            CreateMap<OurTeam, OurTeamDetailsVM>();

            CreateMap<AboutNumber, AboutNumbersVM>().ReverseMap();

            CreateMap<ContactMessage, ContactMessagesVM>().ReverseMap();

            
            CreateMap<AboutNumber, AboutNumberViewModel>().ReverseMap();

            // خريطة Service
            CreateMap<Service, ServiceViewModel>().ReverseMap();

            // خريطة Item
            CreateMap<Item, ItemViewModel>().ReverseMap();

            // خريطة Portfolio مع قائمة Items
            CreateMap<Portfolio, PortfolioItemsViewModel>()
                .ForMember(dest => dest.PortfolioName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            // خريطة OurTeam
            CreateMap<OurTeam, OurTeamViewModel>().ReverseMap();
        }
        
    }
}
