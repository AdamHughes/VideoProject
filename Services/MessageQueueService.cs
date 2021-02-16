using System;
using VideoProject.Models;
using RabbitMQ.Client;




namespace VideoProject.Services
{
    public class MessageQueueService
    {

        private IConnection Connection { get; set; }
        
        public MessageQueueService(IRabbitQueueSettings settings)
        {
            
        }


        



    }
}