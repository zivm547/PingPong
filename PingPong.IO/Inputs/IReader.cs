using System.Threading.Tasks;

namespace PingPong.IO.Inputs 
{
    public interface IReader<T>
    {
        Task<T> Read();
    }
}
