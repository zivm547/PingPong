namespace PingPong.IO.Outputs
{
    public interface IWriter<T>
    {
        void Write(T outputObject);
    }
}
