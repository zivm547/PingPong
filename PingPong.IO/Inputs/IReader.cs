namespace PingPong.IO.Inputs 
{
    public interface IReader<T>
    {
        T Read();
    }
}
