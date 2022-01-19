using System.Threading.Tasks;

namespace PingPong.Common.Sockets.Client.Abstractions
{
    public interface IConnectable
    {
        Task Connect();
    }
}
