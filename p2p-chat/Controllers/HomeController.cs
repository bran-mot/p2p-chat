using Microsoft.AspNetCore.Mvc;
using p2pchat.Services;

namespace p2p_chat.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private LoggingService loggingService;
        private UserService userService;

        public HomeController(LoggingService loggingService, UserService userService)
        {
            this.loggingService = loggingService;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            if (UserService.CurrentUser == null)
            {
                return RedirectToAction("Register");
            }
            loggingService.Log("/", "Index", "Info", "");
            return View();
        }

        [HttpGet("/register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("/register")]
        public IActionResult Register(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Register");
            }
            userService.Login(username);
            return RedirectToAction("Index");

        }

        [HttpGet("/main")]
        public IActionResult Main()
        {
            return View();
        }
    }
}
