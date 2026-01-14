using System;
using System.Collections.Generic;
using System.Text;

namespace PlayingWithTranslink.Gtfs.Models;

public sealed record Trip(string route_id, string service_id, string trip_id, string trip_headsign);
