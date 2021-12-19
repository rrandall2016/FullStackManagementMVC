using FullStackManagementMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackManagementMVC.Controllers
{
    public class StocksController : Controller
    {

        private readonly WebServices webServices;

        //DI being peformed in HomeController
        //Sets up HttpClient and Controller
        public StocksController(WebServices webServices)
        {
            this.webServices = webServices;
        }
        public async Task<IActionResult> Stocks()
        {
            //await webservice
            var asyncResult = await webServices.GetData6("https://api.polygon.io/v2/reference/news?limit=10&order=descending&sort=published_utc&apiKey=");

            return View(asyncResult);
        }
    }
}
