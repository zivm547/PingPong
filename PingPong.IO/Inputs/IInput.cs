using System.Threading.Tasks;

namespace PingPong.IO.Inputs 
{
    public interface IInput<T>
    {
        Task<T> Read();
    }
}
