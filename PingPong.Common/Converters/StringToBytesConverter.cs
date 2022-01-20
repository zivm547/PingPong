using PingPong.Common.Converters.Abstractions;
using System;
using System.Text;

namespace PingPong.Common.Converters
{
    public class StringToBytesConverter : IConverter<string, byte[]>
    {
        public bool TryConvert(string sourceObject, out byte[] outputObject)
        {
            try
            {
                outputObject = Encoding.ASCII.GetBytes(sourceObject);
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
