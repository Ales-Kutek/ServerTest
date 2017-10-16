using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Timers;

namespace ServerTest2.App
{
    public class Listen
    {
        public void Process(List<Client> clients)
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

        private void ListeningProcess(TcpListener listener, List<Client> clients)
        {
            Timer timer = new Timer(1000);

            timer.Elapsed += delegate(object sender, ElapsedEventArgs args)
            {
                try
                {
                    if (listener.Pending())
                    {
                        Console.WriteLine("client is pending..");
                        Client client = new Client(listener.AcceptTcpClient());

                        clients.Add(client);
                        Console.WriteLine("Client added to list");

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            };

            timer.Start();
        }
    }
}