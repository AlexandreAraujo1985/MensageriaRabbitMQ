using System;
using System.Collections.Generic;
using System.Text;

namespace Consumer.Application
{
    public interface IConsumerQueue
    {
        void BasicConsume();
    }
}
