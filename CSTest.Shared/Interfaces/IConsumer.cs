using CSTest.Shared.Model;

namespace CSTest.Shared.Interfaces
{
    public interface IConsumer
    {
        void ReadNext(Trade trade); 
    }
}
