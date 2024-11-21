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
    public class ServicesController : Controller
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ServicesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            
        }


        public IActionResult Index()
        {

            return View(mapper.Map<IEnumerable<ServicesVM>>(context.Services.ToList()));

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(ServiceFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            vm.ImageName = FileSettings.UploadFile(vm.Image, "images");

            var service = mapper.Map<Service>(vm);
            context.Add(service);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));


        }
        [HttpGet]
        public IActionResult Details(int id)
        {

            var service = context.Services.Find(id);


            if (service == null)
            {
                return NotFound();
            }

            return View(mapper.Map<ServiceDetailsVM>(service));
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var service = context.Services.Find(id);
            if (service is null)
            {
                return RedirectToAction(nameof(Index));
            }
            FileSettings.DeleteFile(service.ImageName, "images");
            context.Services.Remove(service);
            context.SaveChanges();
            return Ok(new { message = "service deleted" });
        }

        public IActionResult Edit(int id)
        {
            var service = context.Services.Find(id);
            if (service is null)
            {
                return NotFound();
            }

            var serviceVm = mapper.Map<ServiceFormVM>(service);

            return View(serviceVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ServiceFormVM vm)
        {
            var service = context.Services.Find(vm.Id);
            if (service is null)
            {
                return NotFound();
            }

            if (vm.Image == null)
            {
                ModelState.Remove("Image");

            }
            else
            {
                FileSettings.DeleteFile(service.ImageName, "images");
                vm.ImageName = FileSettings.UploadFile(vm.Image, "images");
            }




            if (!ModelState.IsValid)
            {
                return View(vm);
            }



            mapper.Map(vm, service);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }



    }
}