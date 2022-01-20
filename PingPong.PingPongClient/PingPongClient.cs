using PingPong.Common.Converters;
using PingPong.Common.Converters.Abstractions;
using PingPong.IO.Inputs;
using PingPong.IO.Outputs;
using PingPong.Networking.Wrappers.Sockets.ClientSockets.Abstractions;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PingPong.PingPongClient
{
    public class PingPongClient
    {
        private ClientSocketBase _socket;
        private IConverter<string,byte[]> _stringToByteConverter;
        private IConverter<byte[],string> _byteToStringConverter;
        private IInput<string> _inputSource;
        private IOutput<string> _output;

        public PingPongClient(ClientSocketBase socket,
                            IInput<string> inputSource,
                            IOutput<string> output,
                            StringToBytesConverter stringToByteConverter, 
                            IConverter<byte[], string> byteToStringConverter)
        {
            _socket = socket;
            _inputSource = inputSource;
            _output = output;
            _stringToByteConverter = stringToByteConverter;
            _byteToStringConverter = byteToStringConverter;
        }

        public async Task StartConnection(EndPoint endPoint)
        {
            await _socket.Connect(endPoint);
        }

        public async Task StartPingPong(CancellationToken token)
        {
            while (true)
            {
                token.ThrowIfCancellationRequested();

                var messageToSendToServer = await GetInput();
                await SendServerMessage(messageToSendToServer);

                var receiveMessageFromServer = ReceiveMessageFromServer();
                var serverResponse = await receiveMessageFromServer;

                await _output.Write(serverResponse);
            }
        }

        private async Task SendServerMessage(string message)
        {
            byte[] buffer;

            if (_stringToByteConverter.TryConvert(message, out buffer))
            {
                var writingMessageToServer = _socket.Send(buffer);
                await writingMessageToServer;
            }
        }

        private async Task<string> GetInput()
        {
            var gettingInput = _inputSource.Read();
            var userInput = await gettingInput;
            return userInput;
        }

        private async Task<string> ReceiveMessageFromServer()
        {
            string response;
            var receivingMessage = _socket.Receive();
            var byteMessage = await receivingMessage;

            if (_byteToStringConverter.TryConvert(byteMessage, out response))
            {
                return response;
            }
            return response;
        }
    }
}
