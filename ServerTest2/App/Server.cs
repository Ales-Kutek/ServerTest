﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace ServerTest2.App
{
    public class Server
    {
        private List<Client> _tcpClients = new List<Client>();

        private Task listeningTask;

        public List<Client> GetTcpClients()
        {
            return this._tcpClients;
        }

        public void StartServer()
        {
            Console.WriteLine("server start");

            listeningTask = new Task(delegate
            {
                Listen listenProcess = new Listen();

                listenProcess.Process(this.GetTcpClients());
            });

            listeningTask.Start();

            Timer timer = new Timer(1000);

            ServerLoop loop = new ServerLoop();

//            timer.Elapsed += delegate(object sender, ElapsedEventArgs args)
//            {
            while (true)
            {
                var clients = this.GetTcpClients().ToList();

                loop.Process(clients);

                Thread.Sleep(20);
            }
//            };

//            timer.Start();

            Console.ReadKey();
        }
    }
}