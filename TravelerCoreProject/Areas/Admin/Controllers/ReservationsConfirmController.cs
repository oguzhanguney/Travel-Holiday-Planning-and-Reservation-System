using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace TravelerCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]


    public class ReservationsConfirmController : Controller
    {
        //
        private readonly IReservationService _reservationService;
        private readonly IDestinationService _destinationService;
        private readonly UserManager<AppUser> _userManager;

        public ReservationsConfirmController(IReservationService reservationService, IDestinationService destinationService, UserManager<AppUser> userManager)
        {
            _reservationService = reservationService;
            _destinationService = destinationService;
            _userManager = userManager;
        }

        public  IActionResult Index()
        {
            var values = _reservationService.TGetList().Where(r => r.Status == "Onay Bekliyor").ToList(); 
            return View(values);
        }

        public IActionResult ChangeApprove(int id)
        {
            _reservationService.ChangeToAccept(id);
            return RedirectToAction("Index", "ReservationsConfirm", new { area = "Admin" });
        }
        public IActionResult ChangeReject(int id)
        {
            _reservationService.ChangeToReject(id);
            return RedirectToAction("Index", "ReservationsConfirm", new { area = "Admin" });
        }
    }
}
