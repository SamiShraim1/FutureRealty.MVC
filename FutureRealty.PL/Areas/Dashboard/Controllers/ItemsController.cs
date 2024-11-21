using AutoMapper;
using FutureRealty.DAL.Data;
using FutureRealty.DAL.Models;
using FutureRealty.PL.Areas.Dashboard.ViewModels;
using FutureRealty.PL.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FutureRealty.PL.Areas.Dashboard.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("Dashboard")]
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ItemsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var items = context.Items.Include(i => i.Portfolio) .ToList();

            return View(mapper.Map<IEnumerable<ItemsVM>>(items));

        }
        [HttpGet]
        public IActionResult Create()
        {
            var portfolios = context.Portfolios.ToList();
            var vm = new ItemFormVM
            {
                Portfolios = new SelectList(portfolios, "Id", "Name")
            };

            return View(vm);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(ItemFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            vm.ImageName = FileSettings.UploadFile(vm.Image, "images");

            var Item = mapper.Map<Item>(vm);
            context.Add(Item);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));


        }
        [HttpGet]
        public IActionResult Details(int id)
        {

            var Item = context.Items.Find(id);


            if (Item == null)
            {
                return NotFound();
            }
            var portfolio = context.Portfolios.Find(Item.PortfolioId);
            var ItemVm = mapper.Map<ItemDetailsVM>(Item);
            ItemVm.PortfolioName = portfolio?.Name;

            return View(ItemVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var Item = context.Items.Find(id);
            if (Item is null)
            {
                return RedirectToAction(nameof(Index));
            }
            FileSettings.DeleteFile(Item.ImageName, "images");
            context.Items.Remove(Item);
            context.SaveChanges();
            return Ok(new { message = "item deleted" });
        }

        public IActionResult Edit(int id)
        {
            var Item = context.Items.Find(id);
            if (Item is null)
            {
                return NotFound();
            }

            var portfolios = context.Portfolios.ToList();
            var ItemVm = mapper.Map<ItemFormVM>(Item);
            ItemVm.Portfolios = new SelectList(portfolios, "Id", "Name");


            return View(ItemVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ItemFormVM vm)
        {
            var Item = context.Items.Find(vm.Id);
            if (Item is null)
            {
                return NotFound();
            }

            if (vm.Image == null)
            {
                ModelState.Remove("Image");

            }
            else
            {
                FileSettings.DeleteFile(Item.ImageName, "images");
                vm.ImageName = FileSettings.UploadFile(vm.Image, "images");
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }




            mapper.Map(vm, Item);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }



    }
}