using PingPong.Common.Converters.Abstractions;
using System;
using System.Net;

namespace PingPong.Common.Converters
{
    public class IpAndPortToEndPointConverter : IConverter<(string ip, int port), EndPoint>
    {
        public bool TryConvert((string ip, int port) sourceObject, out EndPoint outputObject)
        {
            IPEndPoint ipEndPoint;
            try
            {
                ipEndPoint = IPEndPoint.Parse(sourceObject.ip);
                ipEndPoint.Port = sourceObject.port;
                outputObject = ipEndPoint;
                return true;
            }
            catch (FormatException)
            {
                outputObject = null;
                return false;
            }
            catch (Exception)
            {
                outputObject = null;
                return false;
            }
        }
    }
}
