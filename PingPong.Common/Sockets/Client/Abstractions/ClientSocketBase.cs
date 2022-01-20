using PingPong.IO.Inputs;
using PingPong.IO.Outputs;
using System.Threading.Tasks;

namespace PingPong.Common.Sockets.Client.Abstractions
{
    public abstract class ClientSocketBase<T> : IConnectable, IWriter<T>, IReader<T>
    {
        protected readonly string _ipAddress;
        protected readonly uint _port;

        protected ClientSocketBase(string ipAddress, uint port)
        {
            _ipAddress = ipAddress;
            _port = port;
        }

        public abstract Task Connect();
        public abstract Task<T> Read();
        public abstract Task Write(T outputObject);
    }
}
