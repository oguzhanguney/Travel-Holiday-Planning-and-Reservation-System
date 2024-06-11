using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using TravelerCoreProject.Models;

namespace TravelerCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;
        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var jsonCity=JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(jsonCity);
        }
        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            destination.Status = true;
            _destinationService.TAdd(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);    
        }

        public IActionResult GetById(int DestinationID)
        {
            var value = _destinationService.TGetByID(DestinationID);
            if (value == null)
            {
                return Json(new { success = false, message = "Böyle bir şehir bulunamamaktadır." });
            }
            else
            {
                var jsonValue = JsonConvert.SerializeObject(value);
                return Json(new { success = true, data = jsonValue });
            }
        }

        public IActionResult DeleteCity(int id)
        {
            var values = _destinationService.TGetByID(id);
            _destinationService.TDelete(values);
            return NoContent();
        }




    }
}
