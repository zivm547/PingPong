using PingPong.Networking.Wrappers.Sockets.ClientSockets.Abstractions;
using System.Net.Sockets;

namespace PingPong.Factories.Abstractions
{
    public interface IClientSocketFactory
    {
        ClientSocketBase CreateNewClientSocket(Socket socket);
    }
}
