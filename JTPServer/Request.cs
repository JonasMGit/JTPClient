using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JTPServer
{
    class Request
    {
        //request format
        public String Method { get; set; }
        public String Path { get; set; }
        //UNIX format
        public long DateTime { get; set; }
        public String Body { get; set; }
        public Request()
        {
            Method = "{}";
        }
        public static Request reqRead(Stream strm, int size)
        {
            var buffer = new byte[size];
            var readCnt = strm.Read(buffer, 0, buffer.Length);
            var request = Encoding.UTF8.GetString(buffer, 0, readCnt);
            Console.WriteLine($"Request: {JsonConvert.SerializeObject(request)}");
            return JsonConvert.DeserializeObject<Request>(request);
        }
    }
}
