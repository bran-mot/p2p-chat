using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using p2p_chat.Models;
using p2pchat.Services;

namespace p2p_chat.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private LoggingService loggingService;

        public HomeController(LoggingService loggingService)
        {
            this.loggingService = loggingService;
        }


        public IActionResult Index()
        {
            loggingService.Log("/", "Index", "Info", "");
            return View();
        }
    }
}
