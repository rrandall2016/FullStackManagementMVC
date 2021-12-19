using FullStackManagementMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackManagementMVC.Controllers
{
    public class PhotosController : Controller
    {
        private readonly WebServices webServices;

        //DI being peformed in HomeController
        //Sets up HttpClient and Controller
        public PhotosController(WebServices webServices)
        {
            this.webServices = webServices;
        }
        public async Task<IActionResult> Photos()
        {
            //await webservice
            var asyncResult = await webServices.GetData5("https://api.unsplash.com/photos/?client_id=x");

            return View(asyncResult);
        }
    }
}
