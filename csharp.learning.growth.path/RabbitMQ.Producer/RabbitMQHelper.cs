using RabbitMQ.Client;

namespace RabbitMQ.Producer
{
    public class RabbitMQHelper
    {
        /// <summary>
        /// 获取单个RabbitMQ连接
        /// </summary>
        /// <returns> IConnection </returns>
        public static IConnection GetConnection()
        {
            var factory = new ConnectionFactory
            {
                HostName = "39.108.87.185", //ip
                Port = 5672, // 端口
                UserName = "admin", // 账户
                Password = "admin", // 密码
                VirtualHost = "forests-hosts"   // 虚拟主机
            };
            return factory.CreateConnection();
        }
    }
}