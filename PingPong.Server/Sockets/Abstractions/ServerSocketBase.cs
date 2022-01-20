using PingPong.Common.Sockets.Client.Abstractions;
using PingPong.Server.Listeners.Abstractions;
using System.Threading.Tasks;

namespace PingPong.Server.Sockets.Abstractions
{
    public abstract class ServerSocketBase : IBinder, IListener
    {
        protected readonly string _ipAddress;
        protected readonly uint _port;

        protected ServerSocketBase(string ipAddress, uint port)
        {
            _ipAddress = ipAddress;
            _port = port;
        }

        public abstract Task<ClientSocketBase<string>> Accept();
        public abstract Task Bind();
        public abstract Task Listen(int numberOfConnections);
        public abstract Task Close();
    }
}
