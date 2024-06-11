using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TravelerCoreProject.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace TravelerCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class BookingHotelSearchController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id=-1456928&search_type=CITY&arrival_date=2024-06-01&departure_date=2024-06-20&adults=1&children_age=0%2C17&room_qty=1&page_number=1&languagecode=tr&currency_code=TRY"),
                Headers =
    {
        { "X-RapidAPI-Key", "2c3a559cccmsh44151517fdc7f67p1b644ejsn79ae9fcbf820" },
        { "X-RapidAPI-Host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var bodyReplace = body.Replace(".", "");
                var values = JsonConvert.DeserializeObject<BookingHotelSearchViewModel.Rootobject>(bodyReplace);

                return View(values.data.hotels);
            }
        }


        //şehire göre otel listeleme:
        [HttpGet]
        public IActionResult GetCityDestID()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetCityDestID(string p)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query={p}"),
                Headers =
    {
        { "X-RapidAPI-Key", "2c3a559cccmsh44151517fdc7f67p1b644ejsn79ae9fcbf820" },
        { "X-RapidAPI-Host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                return View();
            }
        }
    }
}
