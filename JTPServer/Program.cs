using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace JTPServer
{
   /* public class Category
    {
        private int id;
        private string name;

        //This is bad. Make the List generic so it can take all values
        private List<int> cid = new List<int>();
        // List<T> category = new List<T>();
        List<string> cname = new List<string>();
        public Category()
        {
            cid.Add(1);
            cid.Add(2);
            cid.Add(3);
            cname.Add("Beverages");
            cname.Add("Condiments");
            cname.Add("Confections");

        }
        public Category(int id, string name)
        {

            this.id = id;
            this.name = name;

        }
    }*/
    class Program
    {
        
       // Category c = new Category();
        static void Main(string[] args)
        {
            
            // server with local adress and port number   
            var server = new TcpListener(IPAddress.Loopback, 5000);
            // Start listening for client requests.
            server.Start();
            Console.WriteLine("Server started ...");
            
            // Enter the listening loop.
            while (true)
            {
                var client = server.AcceptTcpClient();

                Console.WriteLine("Client connected");

                var thread = new Thread(ClientHandling);

                thread.Start(client);

                //thread.Start(client);
                //methods can go here like update
                //tip from henrik make a thread here
                //listening to port for client 
                //var client = server.AcceptTcpClient();
                //expect client to be first to say something. Stream is the connection. Communicates in both directions
                //Get a stream object for reading and writing
               // var strm = client.GetStream();

                //create buffer before read. Buffer for reading data
                //var buffer = new byte[client.ReceiveBufferSize];
                //read the contents of the stream if the client has sent a request. In this case hello
                //var readCnt = strm.Read(buffer, 0, buffer.Length);
                //Translate data bytes to string. Translate byte hello, to string "hello"
                //var response = Encoding.UTF8.GetString(buffer, 0, readCnt);

                //Console.WriteLine($"Message: {response}");
                // byte array. Convert to uppercase string
           
                //var payload = Encoding.UTF8.GetBytes(response);

                //Sends response back to client
                //strm.Write(payload, 0, payload.Length);

                

                //strm.Close();

                //client.Close();
            }
        }
        public static void ClientHandling(object clientThread)
        {
            if (!(clientThread is TcpClient client))
                return;
                    var stream = client.GetStream();
            try
            {
                
                
                var request = Request.reqRead(stream, client.ReceiveBufferSize);
                //var request = Encoding.UTF8.GetString(buffer, 0, readCnt);
                //var request = stream.Read();
                var response = new Response();
                //It passed!!!
                if (request.Method.Equals("{}"))
                {

                    response.Status += "missing method";
                    Console.WriteLine("ressssspons: " + response.Status);
                }
                WriteRepsonse(stream, response);
                Console.WriteLine("ressssspons: " + response.Status);

                stream.Close();
                client.Close();

                
            }
            
            catch (Exception e)
            {

                Console.WriteLine("Error: " + e);
                return;
            }
            stream.Close();

            client.Close();
        }
        public static void WriteRepsonse(Stream stream, Response response)
        {
            var jsonResponse = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
            stream.Write(jsonResponse, 0, jsonResponse.Length);
           
        }

    }


}
    

