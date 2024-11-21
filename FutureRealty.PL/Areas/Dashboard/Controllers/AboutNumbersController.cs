using AutoMapper;
using FutureRealty.DAL.Data;
using FutureRealty.PL.Areas.Dashboard.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FutureRealty.PL.Areas.Dashboard.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("Dashboard")]
    public class AboutNumbersController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AboutNumbersController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

       
        public IActionResult Index()
        {
            var data = context.AboutNumbers.ToList();


            return View(mapper.Map<AboutNumbersVM>(data[0]));
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Increment(int id, string field)
        {
            var aboutNumbers = context.AboutNumbers.Find(id);
            if (aboutNumbers == null)
            {
                return NotFound();
            }

            switch (field.ToLower())
            {
                case "happyclients":
                    aboutNumbers.HappyClients++;
                    break;
                case "projects":
                    aboutNumbers.Projects++;
                    break;
                case "hoursofsupport":
                    aboutNumbers.HoursOfSupport++;
                    break;
                case "hardworkers":
                    aboutNumbers.HardWorkers++;
                    break;
                default:
                    return BadRequest("Invalid field name");
            }

            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
