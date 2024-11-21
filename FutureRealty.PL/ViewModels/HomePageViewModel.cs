using FutureRealty.DAL.Models;
using FutureRealty.PL.Models;

namespace FutureRealty.PL.ViewModels
{
    public class HomePageViewModel
    {
        public List<AboutNumberViewModel> AboutNumbers { get; set; }
        public List<ServiceViewModel> Services { get; set; }
        public List<PortfolioItemsViewModel> Portfolios { get; set; }
        public List<ItemViewModel> Items { get; set; }
        public List<OurTeamViewModel> OurTeams { get; set; }
        public ContactMessagesVM ContactMessagesVM { get; set; }
    }

    public class AboutNumberViewModel
    {
        public int HappyClients { get; set; }
        public int Projects { get; set; }
        public int HoursOfSupport { get; set; }
        public int HardWorkers { get; set; }
    }

    public class ServiceViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
    }

    public class PortfolioItemsViewModel
    {
        public string PortfolioName { get; set; }
        public List<ItemViewModel> Items { get; set; }
    }

    public class ItemViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
    }

 
    public class OurTeamViewModel
    {
        public string Name { get; set; }
        public string Info { get; set; }
        public string ImageName { get; set; }
        public string? FacebookLink { get; set; }
        public string? linkedinLink { get; set; }
        public string? TwitterLink { get; set; }
    } 


}
