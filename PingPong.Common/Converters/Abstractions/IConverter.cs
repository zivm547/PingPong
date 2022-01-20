using System.Threading.Tasks;

namespace PingPong.Common.Converters.Abstractions
{
    public interface IConverter<TSourceObject, TOutputObject>
    {
        Task<bool> TryConvert(TSourceObject sourceObject, TOutputObject outputObject);
    }
}
