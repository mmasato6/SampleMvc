using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ClientWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClientWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test() 
        {
            return View();
        }

        private string _date = "";
        public IActionResult First() 
        {
            _date = DateTime.Now.ToString();
            this.HttpContext.Session.SetString("data", DateTime.Now.ToString());
            ViewData["data"] = _date;
            ViewData["hash"] = GetHashCode().ToString("X");
            return View();
        }
        public IActionResult Second() 
        {
            //ViewData["data"] = _date; //Controllerはリクエストごとに別インスタンスなのでインスタンス変数の値は消える。
            ViewData["data"] = HttpContext.Session.GetString("data");
            ViewData["hash"] = GetHashCode().ToString("X");
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
