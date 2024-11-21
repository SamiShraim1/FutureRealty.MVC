using AutoMapper;
using FutureRealty.DAL.Data;
using FutureRealty.DAL.Models;
using FutureRealty.PL.Areas.Dashboard.ViewModels;
using FutureRealty.PL.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FutureRealty.PL.Areas.Dashboard.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("Dashboard")]
    public class OurTeamsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public OurTeamsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var teams = context.OurTeams.ToList();
            return View(mapper.Map<IEnumerable<OurTeamDetailsVM>>(teams));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OurTeamFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

         
            if (vm.Image != null)
            {
                vm.ImageName = FileSettings.UploadFile(vm.Image, "images");
            }

            var ourTeam = mapper.Map<OurTeam>(vm);
            context.Add(ourTeam);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var ourTeam = context.OurTeams.Find(id);

            if (ourTeam == null)
            {
                return NotFound();
            }

            var viewModel = mapper.Map<OurTeamDetailsVM>(ourTeam);
            return View(viewModel);
        }

  

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var ourTeam = context.OurTeams.Find(id);
            if (ourTeam == null)
            {
                return RedirectToAction(nameof(Index));
            }


            FileSettings.DeleteFile(ourTeam.ImageName, "images");
            context.OurTeams.Remove(ourTeam);
            context.SaveChanges();
            return Ok(new { message = "team member deleted" });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ourTeam = context.OurTeams.Find(id);
            if (ourTeam == null)
            {
                return NotFound();
            }

            var vm = mapper.Map<OurTeamFormVM>(ourTeam);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OurTeamFormVM vm)
        {
            var ourTeam = context.OurTeams.Find(vm.Id);
            if (ourTeam == null)
            {
                return NotFound();
            }

            if (vm.Image == null)
            {
                ModelState.Remove("Image");
            }
            else
            {
              
                FileSettings.DeleteFile(ourTeam.ImageName, "images");
                
                vm.ImageName = FileSettings.UploadFile(vm.Image, "images");
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            mapper.Map(vm, ourTeam);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
