using FullStackManagementMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using FullStackManagementMVC.Models;

namespace FullStackManagementMVC.Controllers
{
    public class YelpController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public YelpController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IActionResult> Index(string location)
        {

            if (location == " " || location == null)
            {
                location = "Salem-Oregon";
            }
            var client = _clientFactory.CreateClient("Yelp");
            var response = await client.GetAsync($"https://api.yelp.com/v3/businesses/search?location={location}&radius=10000");
            var response2 = await response.Content.ReadFromJsonAsync<Yelp>();
            return View(response2);
        }

 
    }
}
