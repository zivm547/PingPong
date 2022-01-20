using System;
using System.Threading;

namespace PingPong.PingPongServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var port = int.Parse(args[0]);
            var ip = "127.0.0.1";

            Bootstrapper bootstrapper = new Bootstrapper();
            var server = bootstrapper.InitializeServer(ip, port);

            var tokenSource = new CancellationTokenSource();

            server.StartServer(tokenSource.Token).GetAwaiter().GetResult();
        }
    }
}
