using PingPong.Factories.Abstractions;
using PingPong.Networking.Wrappers.Sockets.ClientSockets.Abstractions;
using PingPong.Networking.Wrappers.Sockets.ListenerSockets.Abstractions;
using System.Collections.Concurrent;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PingPong.PingPongServer
{
    public class PingPongServer
    {
        private ListenerSocketBase _serverListener;
        private EndPoint _endPoint;
        private ConcurrentBag<Task> _activeClients;
        private IClientSocketFactory _clientSocketFactory;

        public PingPongServer(ListenerSocketBase serverListener, EndPoint endPoint, IClientSocketFactory clientSocketFactory)
        {
            _serverListener = serverListener;
            _endPoint = endPoint;
            _activeClients = new ConcurrentBag<Task>();
            _clientSocketFactory = clientSocketFactory;
        }

        public async Task StartServer(CancellationToken token)
        {
            await _serverListener.Bind(_endPoint);
            await _serverListener.Listen();

            while (true)
            {
                token.ThrowIfCancellationRequested();

                var newClientSocket = await _serverListener.Accept();

                var clientSocket =_clientSocketFactory.CreateNewClientSocket(newClientSocket);

                var handlingNewClient = HandleClient(clientSocket);
                _activeClients.Add(handlingNewClient);
            }
        }

        private async Task HandleClient(ClientSocketBase newClient)
        {
            
        }
    }
}
