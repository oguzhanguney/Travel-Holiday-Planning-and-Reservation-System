using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using TravelerCoreProject.Areas.Admin.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace TravelerCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class ApiExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<BookingExchangeViewModel> bookingExchangeViewModels = new List<BookingExchangeViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/meta/getExchangeRates?base_currency=TRY"),
                Headers =
    {
        { "X-RapidAPI-Key", "054b64aabemshc142176397f3fa2p123db8jsn70518ad765ce" },
        { "X-RapidAPI-Host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<BookingExchangeViewModel.Rootobject>(body);
                return View(values.data.exchange_rates);
            }
        }
    }
}
