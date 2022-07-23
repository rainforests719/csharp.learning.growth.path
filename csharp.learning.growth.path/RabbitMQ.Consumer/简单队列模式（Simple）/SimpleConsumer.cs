using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQ.Consumer
{
    public class SimpleConsumer
    {
        public static void ReceiveMessage()
        {
            // 消费者消费是队列中消息
            string queueName = "simple_queue";
            var connection = RabbitMQHelper.GetConnection();
            {
                var channel = connection.CreateModel();
                {
                    // 如果你先启动是消费端就会异常
                    channel.QueueDeclare(queueName, false, false, false, null);
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                        Console.WriteLine(" Normal Received => {0}", message);
                    };
                    channel.BasicConsume(queueName, true, consumer);
                }
            }
            Console.ReadLine();
        }

        public static void Main(string[] args) => ReceiveMessage();
    }
}