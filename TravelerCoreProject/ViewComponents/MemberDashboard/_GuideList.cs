using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravelerCoreProject.ViewComponents.MemberDashboard
{
    public class _GuideList:ViewComponent
    {
        //veritabanından  rehberleri getirmek için:
        GuideManager guideManager = new GuideManager(new EfGuideDal());

        public IViewComponentResult Invoke()
        {
            var values = guideManager.TGetList();
            return View(values);
        }
    }
}
