using System;
using static System.Console;

namespace ConAppPlayingWithFundamentals.Services.NotificationService;
public static class EventsHelper
{
	public static void MyEvents()
	{
		NotificationMethods nm = new();
		nm.Show += ShowMethodHandler;
		nm.Name = "Kris";
	}

	private static void ShowMethodHandler(object sender, EventArgs args)
	{
		WriteLine($"Name property has changed...");
	}
}
