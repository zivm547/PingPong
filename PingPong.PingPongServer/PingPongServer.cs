using PingPong.Common.Sockets.Client.Abstractions;
using PingPong.Server.Sockets.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PingPong.PingPongServer
{
    public class PingPongServer
    {
        private ServerSocketBase _serverListener;

        public PingPongServer(ServerSocketBase serverSocket)
        {
            _serverListener = serverSocket;
        }

        public async Task SetupServer(int numberOfActiveConnections, CancellationToken token)
        {
            await _serverListener.Bind();
            await _serverListener.Listen(numberOfActiveConnections);

            while (true)
            {
                token.ThrowIfCancellationRequested();

                var newClient = await _serverListener.Accept();

            }
        }

        private async Task HandleClient(ClientSocketBase<string> newClient)
        {
            
        }
    }
}
