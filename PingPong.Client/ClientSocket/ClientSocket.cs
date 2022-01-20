using PingPong.Common.Sockets.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Client.ClientSocket
{
    public class ClientSocket : ClientSocketBase<string>
    {
        private Socket _socket;

        public ClientSocket(Socket socket, string ipAddress, uint port):
            base(ipAddress, port)
        {
            _socket = socket;
        }

        public override async Task Connect()
        {
            await Task.Run(()=> _socket.Connect(_ipAddress, (int)_port));
        }

        public override async Task<string> Read()
        {
            var buffer = new List<Byte>();

            _socket.Receive((IList<ArraySegment<byte>>)buffer);

            var decode = Task.Run(() => Encoding.ASCII.GetString(buffer.ToArray()));
            var message = await decode;

            return message;
        }

        public override async Task Write(string outputObject)
        {
            var message = Encoding.ASCII.GetBytes(outputObject);
            await Task.Run(()=> _socket.Send(message));
        }
    }
}
