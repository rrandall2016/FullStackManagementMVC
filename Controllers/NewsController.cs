using FullStackManagementMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackManagementMVC.Controllers
{
    //9b2d34c4a37545e0af58651e49c5a7f9
    public class NewsController : Controller
    {
        private readonly WebServices webServices;

        //DI being peformed in HomeController
        //Sets up HttpClient and Controller
        public NewsController(WebServices webServices)
        {
            this.webServices = webServices;
        }
        public async Task<IActionResult> Index()
        {
            //await webservice
            var asyncResult = await webServices.GetData4("https://newsapi.org/v2/top-headlines?country=us&apiKey=9b2d34c4a37545e0af58651e49c5a7f9");

            return View(asyncResult);
        }
    }
}
