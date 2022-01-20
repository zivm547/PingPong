using PingPong.Common.Converters.Abstractions;
using PingPong.Factories.Abstractions;
using PingPong.Networking.Wrappers.Sockets.ClientSockets.Abstractions;
using PingPong.Networking.Wrappers.Sockets.ListenerSockets.Abstractions;
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PingPong.PingPongServer
{
    public class PingPongServer
    {
        private ListenerSocketBase _serverListener;
        private EndPoint _endPoint;
        private ConcurrentBag<Task> _activeClients;
        private IClientSocketFactory _clientSocketFactory;
        private IConverter<string, byte[]> _stringToByteConverter;
        private IConverter<byte[], string> _byteToStringConverter;

        public PingPongServer(ListenerSocketBase serverListener, 
            EndPoint endPoint, 
            IClientSocketFactory clientSocketFactory, 
            IConverter<string, byte[]> stringToByteConverter, 
            IConverter<byte[], string> byteToStringConverter)
        {
            _serverListener = serverListener;
            _endPoint = endPoint;
            _activeClients = new ConcurrentBag<Task>();
            _clientSocketFactory = clientSocketFactory;
            _stringToByteConverter = stringToByteConverter;
            _byteToStringConverter = byteToStringConverter;
        }

        public async Task StartServer(CancellationToken token)
        {
            await _serverListener.Bind(_endPoint);
            await _serverListener.Listen();
            Console.WriteLine("Awaiting Clients");

            while (true)
            {
                token.ThrowIfCancellationRequested();

                var newClientSocket = await _serverListener.Accept();
                Console.WriteLine($"Accepted Client: {newClientSocket}");

                var clientSocket =_clientSocketFactory.CreateNewClientSocket(newClientSocket);

                var handlingNewClient = HandleClient(clientSocket);
                _activeClients.Add(handlingNewClient);
            }
        }

        private async Task HandleClient(ClientSocketBase newClient)
        {
            while (true)
            {
                try
                {
                    if (newClient.Available() > 0)
                    {
                        string message;
                        var clientMessage = await newClient.Receive();
                        _byteToStringConverter.TryConvert(clientMessage, out message);

                        await newClient.Send(clientMessage);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
        }
    }
}
