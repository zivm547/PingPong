using PingPong.Common.Converters;
using PingPong.Networking.Wrappers.Sockets.ClientSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.PingPongClient
{
    public class Bootstrapper
    {
        public PingPongClient InitializeClient(string ip, int port)
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

            return null;
        }
    }
}
