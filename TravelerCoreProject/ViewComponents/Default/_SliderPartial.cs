using Microsoft.AspNetCore.Mvc;

namespace TravelerCoreProject.ViewComponents.Default
{
    public class _SliderPartial:ViewComponent
    {
        //invoke metodu:
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
