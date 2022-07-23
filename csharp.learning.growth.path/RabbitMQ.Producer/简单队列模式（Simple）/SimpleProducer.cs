using System.Text;
using RabbitMQ.Client;

namespace RabbitMQ.Producer.SimpleProducer;

public class SimpleProducer
{
    /*
     * 简单队列（点对点模式）
     **/
    public static void SendMessage()
    {
        string queueName = "simple_queue";
        using (var connection = RabbitMQHelper.GetConnection())
        {
            // 创建信道
            using (var channel = connection.CreateModel())
            {
                // 创建队列
                channel.QueueDeclare(queue: queueName, durable: false, false, false, null);
                while (true)
                {
                    string message = $"Hello Word，Content: {Guid.NewGuid().ToString()}";
                    var body = Encoding.UTF8.GetBytes(message);

                    /*
                     * 默认的交换器隐式地绑定到每个队列，其路由键等于队列名。不能显式地绑定到或取消绑定到默认交换器。也不能删除。
                     **/
                    channel.BasicPublish(exchange: string.Empty, routingKey: queueName, null, body);
                    Console.WriteLine($"Send Simple message => {0}", message);
                    Thread.Sleep(1000);
                }
            }
        }
    }

    public static void Main(string[] args) => SendMessage();
}