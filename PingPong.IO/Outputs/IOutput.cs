using System.Threading.Tasks;

namespace PingPong.IO.Outputs
{
    public interface IOutput<T>
    {
        Task Write(T outputObject);
    }
}
