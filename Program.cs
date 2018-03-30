using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace buoi4
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= int.MaxValue; i++)
            {
                IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.0"), i);
                UdpClient server;
                byte[] data;
                try
                {
                    server = new UdpClient();
                    server.Client.ReceiveTimeout = 1000;
                    server.Connect(ipe);
                    data = new byte[1024];
                    server.Send(data, data.Length);
                    data = server.Receive(ref ipe);
                    Console.WriteLine("{0}: open", ipe);
                }
                catch
                {
                    Console.WriteLine("{0}: Closed", ipe);
                }
            }
        }
    }
}
