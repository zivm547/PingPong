using PingPong.Factories.Abstractions;
using PingPong.Networking.Wrappers.Sockets.ClientSockets;
using PingPong.Networking.Wrappers.Sockets.ClientSockets.Abstractions;
using System.Net.Sockets;

namespace PingPong.Factories
{
    public class ClientSocketFactory : IClientSocketFactory
    {
        public ClientSocketBase CreateNewClientSocket(Socket socket)
        {
            return new ClientSocket(socket);
        }
    }
}
