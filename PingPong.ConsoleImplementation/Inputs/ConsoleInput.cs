using PingPong.IO.Inputs;
using System;
using System.Threading.Tasks;

namespace PingPong.ConsoleImplementation.Inputs
{
    public class ConsoleInput : IInput<string>
    {
        public async Task<string> Read()
        {
            var input = await Task<string>.Run(()=>Console.ReadLine());
            return input;
        }
    }
}
