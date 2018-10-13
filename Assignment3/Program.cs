using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace JTPClient
{

    class Program
    {
        static void Main(string[] args)
        {
            //create a client. Only works if you have a TCPServer 
            //connect to same port as server. Same IP adress as server
            var client = new TcpClient(/*"127.0.0.1", 5000*/);
            // connects client to TCP server
            client.Connect(IPAddress.Loopback, 5000);
            //Writing method
            Console.WriteLine("Enter request:");
            var request = "missing method";

            //Writing path
           
  
            
            //Translate the requested message bytes and store it as a Byte array. 
            //This is required before writing or reading from stream
            var methodMsg = Encoding.UTF8.GetBytes(request);
            //Get a client stream for reading and writing
            var strm = client.GetStream();

            //Send the message to the connected TcpServer. Send a request to server
            strm.Write(methodMsg, 0, methodMsg.Length);
            //buffer to store response bytes
            var buffer = new byte[client.ReceiveBufferSize];
            //read the first batch of TcpServer response bytes
            var readCnt = strm.Read(buffer, 0, buffer.Length);

            var response = Encoding.UTF8.GetString(buffer, 0, readCnt);

            Console.WriteLine($"Response: {response}");
            // Console.WriteLine("Response:", svrMsg);


            strm.Close();

            client.Close();

        }
    }
    
}
