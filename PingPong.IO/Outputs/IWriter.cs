using System.Threading.Tasks;

namespace PingPong.IO.Outputs
{
    public interface IWriter<T>
    {
        Task Write(T outputObject);
    }
}
