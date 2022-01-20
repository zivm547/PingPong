using PingPong.Common.Sockets.Client.Abstractions;
using PingPong.IO.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.PingPongClient
{
    public class PingPongClient
    {
        private ClientSocketBase<string> _socket;
        private IReader<string> _inputSource;

        public PingPongClient(ClientSocketBase<string> socket, IReader<string> inputSource)
        {
            _socket = socket;
            _inputSource = inputSource;
        }

        public async Task StartConnection()
        {
            await _socket.Connect();
        }


    }
}
