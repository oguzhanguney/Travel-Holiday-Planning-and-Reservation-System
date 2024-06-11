using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelerCoreProject.Controllers
{
    [AllowAnonymous]
    public class GuideController : Controller
    {
        GuideManager _guidemanager=new GuideManager(new EfGuideDal());
        public IActionResult Index()
        {
            var values=_guidemanager.TGetList();
            return View(values);
        }
    }
}
