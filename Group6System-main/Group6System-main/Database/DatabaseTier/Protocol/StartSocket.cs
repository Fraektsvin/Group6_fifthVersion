using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace DatabaseTier.Protocol
{
    public class StartSocket
    {
        public void Start()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(ip, 9999); 
            listener.Start();

            Console.WriteLine("Server started...");
             
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                SocketHandler handler = new SocketHandler(client);
                new Thread(() => handleClient(handler)).Start();
                Console.WriteLine("Client connected");
            }
        }

        private async void handleClient(SocketHandler handler)
        {
            while (true)
            {
                await handler.ExchangeMessages();
            }
        }
    }
}