using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWithAsb_Part2.Producer;
public class TopicProducer
{
	private readonly IConfiguration _config;

	public TopicProducer(IConfiguration config)
	{
		_config = config;
	}
}
