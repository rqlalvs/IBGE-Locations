using Locations.Classes;
using Locations.Context;
using Locations.DTO;
using Locations.Models;
using Locations.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Locations.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IIBGEService _ibgeservice;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, IIBGEService ibgeservice, ApplicationDbContext context)
        {
            _logger = logger;
            _ibgeservice = ibgeservice;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ShowAll()
        {
            var result = this.RequestAll();
            List<LocationList> myDeserializedObjList = (List<LocationList>)JsonConvert.DeserializeObject(result, typeof(List<LocationList>));

            return this.View(myDeserializedObjList);
        }

        public string RequestAll()
        {
            var reqall = _ibgeservice.RequestAll();
            return reqall;
        }

        public string RequestOne(int id)
        {
            var reqone = _ibgeservice.RequestOne(id);

            return reqone;
        }
    }
}