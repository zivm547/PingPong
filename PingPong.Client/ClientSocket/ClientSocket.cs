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
            await _socket.ConnectAsync(_ipAddress, (int)_port);
        }

        public override string Read()
        {
            var message = new List<Byte>();
            _socket.Receive((IList<ArraySegment<byte>>)message);
            return Encoding.ASCII.GetString(message.ToArray());
        }

        public override void Write(string outputObject)
        {
            var message = Encoding.ASCII.GetBytes(outputObject);
            _socket.Send(message);
        }
    }
}
