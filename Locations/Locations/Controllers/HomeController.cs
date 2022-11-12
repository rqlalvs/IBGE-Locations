using Locations.Classes;
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

        public HomeController(ILogger<HomeController> logger, IIBGEService ibgeservice)
        {
            _logger = logger;
            _ibgeservice = ibgeservice;
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
            List<Location> myDeserializedObjList = (List<Location>)JsonConvert.DeserializeObject(result, typeof(List<Location>));

            return this.View(myDeserializedObjList);
        }

        public IActionResult ShowDB()
        {
            //consulta no DB oq ta salvo
            return this.View();
        }

        public string RequestAll()
        {
            var reqall = _ibgeservice.RequestAll();
            return reqall;
        }

        public string RequestOne()
        {
            Random rd = new Random();
            int rand_num = rd.Next(100, 200);


            var ldto = new LocationDTO();
            var reqone = _ibgeservice.RequestOne(rand_num);
            return reqone;
        }
    }
}