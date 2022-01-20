using System.Threading;

namespace PingPong.PingPongClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = args[0];
            int port = int.Parse(args[1]);

            var tokenSource = new CancellationTokenSource();

            var bootstrapper = new Bootstrapper();
            var client = bootstrapper.InitializeClient(ip, port).GetAwaiter().GetResult();

            client.StartPingPong(tokenSource.Token).GetAwaiter().GetResult();
        }
    }
}
