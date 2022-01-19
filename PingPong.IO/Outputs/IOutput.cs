namespace PingPong.IO.Outputs
{
    public interface IOutput<T>
    {
        void SendOutput(T outputObject);
    }
}
