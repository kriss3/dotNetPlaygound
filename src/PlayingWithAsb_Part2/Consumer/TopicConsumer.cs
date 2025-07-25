using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWithAsb_Part2.Consumer;
internal class TopicConsumer
{
	private readonly IConfiguration _config;
	private ServiceBusProcessor? _processor;

	public TopicConsumer(IConfiguration config)
	{
		_config = config;
	}
}
