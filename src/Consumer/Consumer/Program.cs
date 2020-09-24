using Consumer.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start container Ioc
            var serviceCollection = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IConsumerQueue, ConsumerQueue>()
                .BuildServiceProvider();

            //Start to services
            var consumer = serviceCollection.GetService<IConsumerQueue>();
            consumer.BasicConsume();
        }
    }
}
