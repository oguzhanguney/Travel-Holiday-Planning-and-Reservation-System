using BusinessLayer.Abstract.AbstractUOW;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TravelerCoreProject.Areas.Admin.Models;

namespace TravelerCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AccountViewModel model)
        {
            var valueSender=_accountService.TGetByID(model.SenderID);
            var valueReceiver=_accountService.TGetByID(model.ReceiverID);
            valueSender.Balance -= model.Amount;
            valueReceiver.Balance += model.Amount;
            List<Account> modifiedAccounts = new List<Account>()
            {
                valueSender,
                valueReceiver
            };
            _accountService.TMultiUpdate(modifiedAccounts);

            return View();
        }
    }
}
