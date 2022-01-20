using PingPong.IO.Outputs;
using System;
using System.Threading.Tasks;

namespace PingPong.ConsoleImplementation.Outputs
{
    public class ConsoleOutput : IOutput<string>
    {
        public async Task Write(string outputObject)
        {
            await Task.Run(()=> Console.WriteLine());
        }
    }
}
