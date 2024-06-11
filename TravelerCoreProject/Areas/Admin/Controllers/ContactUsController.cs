using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelerCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]

    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            var values=_contactUsService.TGetListContactUsByTrue();
            return View(values);
        }

        public IActionResult Detail(int id)
        {
            var values = _contactUsService.TGetByID(id);
            return View(values);
        }
        public IActionResult Delete(int id)
        {
            var values = _contactUsService.TGetByID(id);
            _contactUsService.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
