using System;
namespace p2pchat.Models
{
    public class Log
    {
        //Path: The path of the endpoint like: /
        //Method: The method of the endpoint like: GET
        //Date and Time: It should print the date in a format like this: 2017-05-16 21:47:19.040
        //Log Level: INFO on http requests and ERROR on any occured error
        //Request Data: It should log all the request params from the endpoint
        //The log should look like this: 2017-05-16 21:47:19.040 INFO Request /message POST text= apple

        //public string Path { get; set; }
        //public string Method { get; set; }
        //public DateTime Timestamp { get; set; }
        //public string LogLevel { get; set; }
        //public string ReqData { get; set; }
    }
}
