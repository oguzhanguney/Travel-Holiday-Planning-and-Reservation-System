using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelerCoreProject.CQRS.Commands.DestinationCommands;
using TravelerCoreProject.CQRS.Handlers.DestinationHandlers;
using TravelerCoreProject.CQRS.Queries.DestinationQueries;

namespace TravelerCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]//aynı sayfaya yönlendirme yapabilmek için:
    [Authorize(Roles = "Admin")]

    public class DestinationCQRSController : Controller
    {
        //handler sınıfını (listeleme)  çağırmak için:
        private readonly GetAllDestinationQueryHandler _getAllDestinationQueryHandler;
        //handler sınıfını (parametreli getirme)  çağırmak için:
        private readonly GetDestinationByIDQueryHandler _getDestinationByIDQueryHandler;
        //handler sınıfını (parametreli ekleme)  çağırmak için:
        private readonly CreateDestinationCommandHandler _createDestinationCommandHandler;
        //handler sınıfını (parametreye göre silme)  çağırmak için:
        private readonly RemoveDestinationCommandHandler _removeDestinationCommandHandler;
        //handler sınıfını (parametreye göre güncelleme)  çağırmak için:
        private readonly UpdateDestinationCommandHandler _updateDestinationCommandHandler;
        //ctors
        public DestinationCQRSController(GetAllDestinationQueryHandler getAllDestinationQueryHandler, GetDestinationByIDQueryHandler getDestinationByIDQueryHandler, CreateDestinationCommandHandler createDestinationCommandHandler, RemoveDestinationCommandHandler removeDestinationCommandHandler, UpdateDestinationCommandHandler updateDestinationCommandHandler)
        {
            _getAllDestinationQueryHandler = getAllDestinationQueryHandler;
            _getDestinationByIDQueryHandler = getDestinationByIDQueryHandler;
            _createDestinationCommandHandler = createDestinationCommandHandler;
            _removeDestinationCommandHandler = removeDestinationCommandHandler;
            _updateDestinationCommandHandler = updateDestinationCommandHandler;
        }
        public IActionResult Index()
        {
            var values = _getAllDestinationQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult GetDestination(int id)
        {
            var values = _getDestinationByIDQueryHandler.Handle(new GetDestinationByIDQuery(id));
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(CreateDestinationCommand command)
        {
            _createDestinationCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDestination(int id)
        {
            _removeDestinationCommandHandler.Handle(new RemoveDestinationCommand(id));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult GetDestination(UpdateDestinationCommand command)
        {
            _updateDestinationCommandHandler.Handle(command);
            return RedirectToAction("Index");

        }
    }
}
