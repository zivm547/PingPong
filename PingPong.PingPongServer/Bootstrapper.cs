using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using PingPong.Common.Converters;
using PingPong.Factories;
using PingPong.Networking.Wrappers.Sockets.ListenerSockets;

namespace PingPong.PingPongServer
{
    public class Bootstrapper
    {
        public PingPongServer InitializeServer(string ip, int port)
        {
            var stringToByte = new StringToBytesConverter();
            var byteToString = new BytesToStringConverter();
            var ipConverter = new IpAndPortToEndPointConverter();
            IPEndPoint serverEndPoint;

            if(!ipConverter.TryConvert((ip, port), out serverEndPoint))
            {
                throw new FormatException("Error Converting ip and port to end point");
            }

            var listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var serverSocket = new ListenerSocket(listenerSocket);

            var clientSocketFactory = new ClientSocketFactory();

            var server = new PingPongServer(serverSocket, serverEndPoint, clientSocketFactory, stringToByte, byteToString);
            return server;
        }
    }
}
