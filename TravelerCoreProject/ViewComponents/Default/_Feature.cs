using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravelerCoreProject.ViewComponents.Default
{
    public class _Feature:ViewComponent
    {
        //Feature tablosundan veri çekelim.
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
        public IViewComponentResult Invoke()
        {
            //var values=featureManager.TGetList();
            //ViewBag.image1=featureManager.TGetList();
            return View();
        }
    }
}
