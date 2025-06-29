using ConAppPlayingWithObservablePattern.Interfaces;

namespace ConAppPlayingWithObservablePattern.Concretions;

//Important => coupling with the concretion on purpose and this is OK.
public class PhoneDisplay(WeatherStation weatherStation) : IObserver
{
	private readonly WeatherStation _weatherStation = weatherStation;

	public Task Update()
	{
		_weatherStation.GetTemperature();
		return Task.CompletedTask;
	}
}
