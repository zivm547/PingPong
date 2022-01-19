using System.Threading.Tasks;

namespace PingPong.Server.Listeners.Abstractions
{
    public interface IBinder
    {
        Task Bind();
    }
}
