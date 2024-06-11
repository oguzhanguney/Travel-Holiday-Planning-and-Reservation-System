using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravelerCoreProject.ViewComponents.Default
{
    public class _Testimonial:ViewComponent
    {
        ////Testimonial tablosundan veri çekelim.
        TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());
        public IViewComponentResult Invoke()
        {
            var values=testimonialManager.TGetList();
            return View(values);
        }
    }
}
