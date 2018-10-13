using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JTPServer
{
    class Response
    {
        public string Status { get; set; }
        public string Body { get; set; }
        //getter and setter
        public Response()
        {

        }
                
        //bunch of constructors

        public Response(string status, string body = null)
        {
            this.Status = status;
            this.Body = body;
        }

        public Response(Status status, string body = null)
        {
            this.Body = body;
            this.Status = $"{status.GetStatusCode()} {status.getStatusType()}";
            if (status.StatusMessage != null)
            {
                this.Status += $": {status.StatusMessage}";
            }
        }

        public Response(List<Status> statuses, string body = null)
        {
            this.Body = body;

            for (int i = 0; i < statuses.Count; i++)
            {
                this.Status += $"{statuses[i].GetStatusCode()} {statuses[i].getStatusType()}";
                if (statuses[i].StatusMessage != null)
                {
                    this.Status += $": {statuses[i].StatusMessage}";
                }

                if (i < statuses.Count + -1)
                {
                    this.Status += "\n";
                }
            }
        }
       /* public static void WriteRepsonse(Stream stream, Response response)
        {
            var jsonResponse = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
            stream.Write(jsonResponse, 0, jsonResponse.Length);
        }*/
    }
    
}
