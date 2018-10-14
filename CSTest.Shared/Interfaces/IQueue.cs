namespace CSTest.Shared.Interfaces
{
    public interface IQueue<T>
    {
        void Queue(T item);


        T DeQueue();
    }
}
