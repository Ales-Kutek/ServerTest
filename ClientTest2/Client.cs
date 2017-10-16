using System.Net.Sockets;

namespace ClientTest2
{
    public class Client
    {
        private TcpClient tcp;

        private EntityManager em;

        public Client(TcpClient tcp)
        {
            this.tcp = tcp;
            this.em = new EntityManager(this);
        }

        public TcpClient Tcp
        {
            get => tcp;
        }

        public EntityManager EntityManager
        {
            get => em;
        }
    }
}