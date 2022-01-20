using PingPong.Common.Converters;
using PingPong.ConsoleImplementation.Inputs;
using PingPong.ConsoleImplementation.Outputs;
using PingPong.Networking.Wrappers.Sockets.ClientSockets;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace PingPong.PingPongClient
{
    public class Bootstrapper
    {
        public async Task<PingPongClient> InitializeClient(string ip, int port)
        {
            var stringToByte = new StringToBytesConverter();
            var byteToString = new BytesToStringConverter();
            var ipConverter = new IpAndPortToEndPointConverter();
            IPEndPoint serverEndPoint;

            if (!ipConverter.TryConvert((ip, port), out serverEndPoint))
            {
                throw new FormatException("Error Converting ip and port to end point");
            }

            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var clientSocket = new ClientSocket(socket);

            var consoleInput = new ConsoleInput();
            var consoleOutput = new ConsoleOutput();

            var client = new PingPongClient(clientSocket, consoleInput, consoleOutput, stringToByte, byteToString);
            await client.StartConnection(serverEndPoint);

            return client;
        }
    }
}
