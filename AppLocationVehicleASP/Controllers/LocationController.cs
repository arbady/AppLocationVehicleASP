using AppLocationVehicleASP.Models;
using AppLocationVehicleASP.Tools;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Controllers
{
    public class LocationController : Controller
    {
        private readonly ISecurity _requester;

        public LocationController(ISecurity requester)
        {
            _requester = requester;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categories() 
        {
            return View(_requester.Get<IEnumerable<Category>>("Category"));
        }

        // GET: LocationController/Category
        public IActionResult Category(int id)
        {
            return View(_requester.Get<IEnumerable<Vehicle>>("Vehicle/Category/"+id));
        }
    }
}
