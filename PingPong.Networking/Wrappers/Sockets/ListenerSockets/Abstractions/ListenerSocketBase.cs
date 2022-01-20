using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace PingPong.Networking.Wrappers.Sockets.ListenerSockets.Abstractions
{
    public abstract class ListenerSocketBase
    {
        public abstract Task Bind(EndPoint endPoint);
        public abstract Task Listen();
        public abstract Task<Socket> Accept();
        public abstract Task Close();
    }
}
