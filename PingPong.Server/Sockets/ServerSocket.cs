using PingPong.Client.ClientSocket;
using PingPong.Common.Sockets.Client.Abstractions;
using PingPong.Server.Sockets.Abstractions;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace PingPong.Server.Sockets
{
    public class ServerSocket : ServerSocketBase
    {
        private Socket _serverSocket;
        private IPEndPoint _endPoint;

        public ServerSocket(Socket serverSocket, string ipAddress, uint port)
            :base(ipAddress, port)
        {
            _serverSocket = serverSocket;
        }

        public override async Task<ClientSocketBase<string>> Accept()
        {
            var acceptClient = _serverSocket.AcceptAsync();
            var newClientSocket = await acceptClient;
            var newClient = new ClientSocket(newClientSocket, _ipAddress, _port);
            return newClient;
        }

        public override async Task Bind()
        {
            _endPoint = IPEndPoint.Parse(_ipAddress);
            _endPoint.Port = (int)_port;
            await Task.Run(()=> _serverSocket.Bind(_endPoint));
        }

        public override async Task Close()
        {
            await Task.Run(()=>_serverSocket.Close());
        }

        public override async Task Listen(int numberOfConnections)
        {
            await Task.Run(()=>_serverSocket.Listen(numberOfConnections));
        }
    }
}
