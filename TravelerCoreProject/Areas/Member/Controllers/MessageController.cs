using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelerCoreProject.Areas.Member.Controllers
{
    [Authorize]
    [Area("Member")]

    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
