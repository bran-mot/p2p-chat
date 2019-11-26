using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using p2pchat.Data;
using p2pchat.Models;
using p2pchat.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace p2pchat.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ApiController : Controller
    {
        private ApplicationContext applicationContext { get; set; }
        private MessageService messageService { get; set; }

        public ApiController(ApplicationContext applicationContext, MessageService messageService)
        {
            this.applicationContext = applicationContext;
            this.messageService = messageService;
        }

        [HttpGet("message")]
        public Message test()
        {
            using (var db = applicationContext)
            {
                return db.Messages.First();
            }
        }

        [HttpPost("message/receive")]
        public ActionResult ApiMessage([FromBody]Message message)
        {
            using(var db = applicationContext)
            {

                var checkUser = db.Users.FirstOrDefault(u => u.Id == message.SenderId);
                string checkResult = messageService.CheckJsonFields(message);
                
                if (checkResult == "")
                {
                    if (checkUser == null)
                    {
                        return BadRequest(new
                        {
                            status = "error",
                            error = "user doesn't exist"
                        });
                    }
                    db.Messages.Add(message);
                    return Ok(new
                    {
                        status = "Ok"
                    });
                }
                return BadRequest(new
                {
                    status = "error",
                    message = "Missing field(s): " + checkResult
                });
            }
        }
    }
}
