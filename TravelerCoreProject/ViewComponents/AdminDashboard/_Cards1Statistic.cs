using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TravelerCoreProject.ViewComponents.AdminDashboard
{
    public class _Cards1Statistic:ViewComponent
    {
        //veritabanından dinamik olarak istatiksel veri çekebilmek için:
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Destinations.Count();
            ViewBag.v2 = c.Users.Count();
            return View();
        }
    }
}
