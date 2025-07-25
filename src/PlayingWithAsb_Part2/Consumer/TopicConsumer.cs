using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;

namespace PlayingWithAsb_Part2.Consumer;
public class TopicConsumer(IConfiguration config)
{
	private readonly IConfiguration _config = config;
	private ServiceBusProcessor? _processor;
}
