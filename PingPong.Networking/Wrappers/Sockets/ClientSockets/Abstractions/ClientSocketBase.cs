using System.Net;
using System.Threading.Tasks;

namespace PingPong.Networking.Wrappers.Sockets.ClientSockets.Abstractions
{
    public abstract class ClientSocketBase
    {
        public abstract Task Connect(IPEndPoint ip, int port);
        public abstract Task Send(byte[] buffer);
        public abstract Task<byte[]> Receive();
        public abstract Task Close();
    }
}
