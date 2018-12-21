using RabbitMQ.Client;

namespace Pikamese.Models
{
    public enum ExchangeTypes { Direct, Fanout, Headers, Topic }

    public class Exchange
    {
        public ExchangeTypes Type { get; set; }
        public string Name { get; set; }

        public Exchange()
        {
        }


        
    }
}
