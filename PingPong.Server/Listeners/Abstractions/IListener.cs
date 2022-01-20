using PingPong.Common.Sockets.Client.Abstractions;
using System.Threading.Tasks;

namespace PingPong.Server.Listeners.Abstractions
{
    public interface IListener
    {
        Task Listen(int numberOfConnections);
        Task<ClientSocketBase<string>> Accept();
    }
}
