using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWithAsb_Part2.Consumer;
public class TopicConsumer(IConfiguration config)
{
	private readonly IConfiguration _config = config;
	private ServiceBusProcessor? _processor;
}
