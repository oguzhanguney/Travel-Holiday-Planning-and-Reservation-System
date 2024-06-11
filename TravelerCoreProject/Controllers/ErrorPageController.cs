using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelerCoreProject.Controllers
{
    [AllowAnonymous]
    public class ErrorPageController : Controller
    {
        public IActionResult Error404(int code)
        {

            return View();
        }

        public IActionResult Error403()
        {
            return View();
        }
        
    }
}
