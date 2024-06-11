using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TravelerCoreProject.Controllers
{
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());

        private readonly UserManager<AppUser> _userManager;

        public DestinationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> DestinationDetails(int id) 
        {
            ViewBag.i=id;
            ViewBag.destID = id;
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName=value.Name +" "+ value.Surname;
            ViewBag.userID = value.Id;
            var values=destinationManager.TGetDestinationWithGuide(id);
            return View(values);
        }
        //
        [Authorize]
        [HttpPost]
        public IActionResult DestinationDetails(Destination p)
        {
            return View();
        }
        
    }
}
