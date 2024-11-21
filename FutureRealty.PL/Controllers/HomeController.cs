using AutoMapper;
using FutureRealty.DAL.Data;
using FutureRealty.DAL.Models;
using FutureRealty.PL.Models;
using FutureRealty.PL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FutureRealty.PL.Controllers
{
   [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public HomeController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var aboutNumbers = mapper.Map<List<AboutNumberViewModel>>(context.AboutNumbers.ToList());
            var services = mapper.Map<List<ServiceViewModel>>(context.Services.ToList());
            var portfolios = mapper.Map<List<PortfolioItemsViewModel>>(context.Portfolios.Include(p => p.Items).ToList());
            var ourTeams= mapper.Map<List<OurTeamViewModel>>(context.OurTeams.ToList());
            

            var viewModel = new HomePageViewModel
            {
                AboutNumbers = aboutNumbers,
                Services = services,
                Portfolios = portfolios,
                OurTeams = ourTeams,
                ContactMessagesVM = new ContactMessagesVM(),

            };

          
          
            return View(viewModel);
        }
        public IActionResult ServiceDetails()
        {
            return View();
        }

        public IActionResult PortfolioDetails()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    
}

