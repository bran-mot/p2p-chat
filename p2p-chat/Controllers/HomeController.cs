using Microsoft.AspNetCore.Mvc;
using p2pchat.Services;

namespace p2p_chat.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private LoggingService loggingService;
        private UserService userService;
        private MessageService messageService;

        public HomeController(LoggingService loggingService, UserService userService, MessageService messageService)
        {
            this.loggingService = loggingService;
            this.userService = userService;
            this.messageService = messageService;
        }

        public IActionResult Index()
        {
            if (UserService.CurrentUser == null)
            {
                return RedirectToAction("Register");
            }
            loggingService.Log("/", "Index", "Info", "");
            return View(messageService.GetMessages());
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

        [HttpPost("/send")]
        public IActionResult Send(string message)
        {
            messageService.SendMessage(message);
            return RedirectToAction("Index");
        }
    }
}
