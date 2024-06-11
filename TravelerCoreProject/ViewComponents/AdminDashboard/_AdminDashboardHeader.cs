using Microsoft.AspNetCore.Mvc;

namespace TravelerCoreProject.ViewComponents.AdminDashboard
{
    public class _AdminDashboardHeader:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
