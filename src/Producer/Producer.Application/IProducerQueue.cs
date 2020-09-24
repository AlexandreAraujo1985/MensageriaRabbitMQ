namespace Producer.Application
{
    public interface IProducerQueue
    {
        void BasicPublish();
    }
}
