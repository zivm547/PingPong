using System.Threading.Tasks;

namespace PingPong.Common.Converters.Abstractions
{
    public interface IConverter<TSourceObject, TOutputObject>
    {
        bool TryConvert(TSourceObject sourceObject, out TOutputObject outputObject);
    }
}
