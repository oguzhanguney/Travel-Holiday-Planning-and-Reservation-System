using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TravelerCoreProject.ViewComponents.MemberDashboard
{
    public class _ProfileInformation:ViewComponent
    {
        //kullanıcı bilgilerine erişmek  için:(ayrıca bir ctor oluşturmalıyız)
        private readonly UserManager<AppUser> _userManager;

        public _ProfileInformation(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult>  InvokeAsync()
        {
            //sisteme giren kullanıcın bilgilerini almak için:
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.memberName = values.Name + " " + values.Surname;
            ViewBag.memberPhone = values.PhoneNumber;
            ViewBag.memberMail = values.Email;
            return View();
        }
    }
}
