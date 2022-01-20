using PingPong.Common.Sockets.Client.Abstractions;
using PingPong.IO.Inputs;
using PingPong.IO.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PingPong.PingPongClient
{
    public class PingPongClient
    {
        private ClientSocketBase<string> _socket;
        private IReader<string> _inputSource;
        private IWriter<string> _output;

        public PingPongClient(ClientSocketBase<string> socket, IReader<string> inputSource, IWriter<string> output)
        {
            _socket = socket;
            _inputSource = inputSource;
            _output = output;
        }

        public async Task StartConnection()
        {
            await _socket.Connect();
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
            var writingMessageToServer = _socket.Write(message);
            await writingMessageToServer;
        }

        private async Task<string> GetInput()
        {
            var gettingInput = _inputSource.Read();
            var userInput = await gettingInput;
            return userInput;
        }

        private async Task<string> ReceiveMessageFromServer()
        {
            var receivingMessage = _socket.Read();
            return await receivingMessage;
        }
    }
}
