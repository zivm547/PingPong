using PingPong.Networking.Wrappers.Sockets.ClientSockets.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Networking.Wrappers.Sockets.ClientSockets
{
    public class ClientSocket : ClientSocketBase
    {
        private Socket _socket;

        public ClientSocket(Socket socket)
        {
            _socket = socket;
        }

        public override async Task Close()
        {
            await Task.Run(()=> _socket.Close());
        }

        public override async Task Connect(EndPoint endPoint)
        {
            await Task.Run(() => _socket.Connect(endPoint));
        }

        public override async Task<byte[]> Receive()
        {
            var buffer = new List<byte>();

            await _socket.ReceiveAsync(buffer as IList<ArraySegment<byte>>, SocketFlags.None);

            return buffer.ToArray<byte>();
        }

        public override async Task Send(byte[] buffer)
        {
            await Task.Run(()=> _socket.Send(buffer));
        }
    }
}
