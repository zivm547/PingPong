using PingPong.Networking.Wrappers.Sockets.ListenerSockets.Abstractions;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace PingPong.Networking.Wrappers.Sockets.ListenerSockets
{
    public class ListenerSocket : ListenerSocketBase
    {
        private Socket _listener;

        public ListenerSocket(Socket listener)
        {
            _listener = listener;
        }

        public override async Task<Socket> Accept()
        {
            var acceptingNewClient = _listener.AcceptAsync();
            var newClient = await acceptingNewClient;
            return newClient;
        }

        public override async Task Bind(EndPoint endPoint)
        {
            await Task.Run(() => _listener.Bind(endPoint));
        }

        public override async Task Close()
        {
            await Task.Run(() => _listener.Close());
        }

        public override async Task Listen()
        {
            await Task.Run(() => _listener.Listen());
        }
    }
}
