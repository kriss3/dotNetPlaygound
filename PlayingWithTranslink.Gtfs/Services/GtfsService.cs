using System;
using System.Collections.Generic;
using System.Text;

namespace PlayingWithTranslink.Gtfs.Services;

public sealed class GtfsService
{
	private readonly string _gtfsFolder;

	public GtfsService(string gtfsFolder)
	{
		_gtfsFolder = gtfsFolder ?? throw new ArgumentNullException(nameof(gtfsFolder));
	}
}
