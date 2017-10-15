using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace ServerTest2.App
{
    public class Listen
    {
        public void Process(List<TcpClient> clients)
        {
            TcpListener listener = null;

            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8081);
                listener.Start();

                this.ListeningProcess(listener, clients);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        private void ListeningProcess(TcpListener listener, List<TcpClient> clients)
        {
            while (true)
            {
                try
                {
                    if (listener.Pending())
                    {
                        Console.WriteLine("client is pending..");
                        TcpClient client = listener.AcceptTcpClient();

                        clients.Add(client);
                        Console.WriteLine("Client added to list");

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}