using Producer.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start container Ioc
            var serviceCollection = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IProducerQueue, ProducerQueue>()
                .BuildServiceProvider();

            //Start to services
            var producer = serviceCollection.GetService<IProducerQueue>();
            producer.BasicPublish();

        }
    }
}
