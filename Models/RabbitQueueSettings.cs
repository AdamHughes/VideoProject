using System.Dynamic;

namespace VideoProject.Models
{
    // RabbitMQ connection settings
    public class RabbitQueueSettings : IRabbitQueueSettings
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string VirtualHost{ get;set; }
        public string Hostname { get; set; }
        public string HostPort { get; set; }
    }
    
    public interface IRabbitQueueSettings
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string VirtualHost{ get;set; }
        public string Hostname { get; set; }
        public string HostPort { get; set; }
        
    }
}