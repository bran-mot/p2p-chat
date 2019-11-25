using System;
namespace p2pchat.Services
{
    public class LoggingService
    {
        public void Log(string path, string method, string logLevel, string reqData)
        {
            if (logLevel == "info")
            {
                Console.WriteLine($"{DateTime.Now} {logLevel} Request {path} {method} {reqData}");
            }
            else
            {
                Console.Error.WriteLine($"{DateTime.Now} {logLevel} Request {path} {method} {reqData}");
            }
        }
    }
}
