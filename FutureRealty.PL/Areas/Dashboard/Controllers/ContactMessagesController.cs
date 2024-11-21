using AutoMapper;
using FutureRealty.DAL.Data;
using FutureRealty.DAL.Models;
using FutureRealty.PL.Areas.Dashboard.ViewModels;
using FutureRealty.PL.Models;
using FutureRealty.PL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FutureRealty.PL.Areas.Dashboard.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("Dashboard")]
    public class ContactMessagesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ContactMessagesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;

        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Submit(HomePageViewModel model)
        {
            var vm = model.ContactMessagesVM;

            if (vm != null)
            {
                var message = mapper.Map<ContactMessage>(vm);
                context.ContactMessages.Add(message);
                context.SaveChanges();

                return Json(new { success = true, message = "Message submitted successfully" });
            }

            return Json(new { success = false, message = "Failed to submit message" });
        }



        public IActionResult Index()
        {
           var  data = context.ContactMessages.ToList();
            var messages = mapper.Map<IEnumerable<ContactMessagesVM>>(data);
            return View(messages);
        }


        [HttpGet]
        public IActionResult Details(int id)
        {

            var message = context.ContactMessages.Find(id);


            if (message == null)
            {
                return NotFound();
            }

            return View(mapper.Map<ContactMessagesVM>(message));
        }

        [HttpPost]
        public IActionResult ToggleStatus(int id)
        {
            var message = context.ContactMessages.Find(id);
            if (message == null)
            {
                return NotFound(new { message = "Message not found" });
            }

            message.InWork = !message.InWork;
            context.SaveChanges();

            return Ok(new { message = "status updated" });
        }



    }
}
