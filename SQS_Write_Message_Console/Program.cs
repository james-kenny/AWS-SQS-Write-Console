using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace SQS_Write_Message_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting..");

            string sQueue = "https://sqs.eu-west-1.amazonaws.com/{CODE}/{QUEUENAME}"; // Region / CODE and QueueName

            try
            {
                var config = new AmazonSQSConfig()
                {
                    ServiceURL = "https://sqs.eu-west-1.amazonaws.com/" // Region and URL
                };

                var _messageRequest = new SendMessageRequest();

                _messageRequest.QueueUrl = sQueue;

                _messageRequest.MessageBody = "This is a test message";

                AmazonSQSClient _client = new AmazonSQSClient("ACCESSKEY", "ACCESSSECRET", config);

                SendMessageResponse sendMessageResponse = _client.SendMessage(_messageRequest);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }

            Console.WriteLine("Complete");
        }
    }
}
