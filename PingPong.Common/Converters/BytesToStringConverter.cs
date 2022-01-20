using PingPong.Common.Converters.Abstractions;
using System;
using System.Text;

namespace PingPong.Common.Converters
{
    public class BytesToStringConverter : IConverter<byte[], string>
    {
        public bool TryConvert(byte[] sourceObject, out string outputObject)
        {
            try
            {
                outputObject = Encoding.ASCII.GetString(sourceObject);
            }
            catch (Exception)
            {
                outputObject = null;
                return false;
            }
            return true;
        }
    }
}
