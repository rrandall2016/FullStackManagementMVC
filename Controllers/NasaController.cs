using FullStackManagementMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackManagementMVC.Controllers
{
    public class NasaController : Controller
    {

            private readonly WebServices webServices;

            //DI being peformed in HomeController
            //Sets up HttpClient and Controller
            public NasaController(WebServices webServices)
            {
                this.webServices = webServices;
            }
            public async Task<IActionResult> Index()
            {
            //await webservice
            var asyncResult = await webServices.GetData2("https://api.nasa.gov/planetary/apod?api_key=");

            return View(asyncResult);
            }
    }
}
