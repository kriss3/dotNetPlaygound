
namespace PlayingWithBackgroudWork.Services;

public class BackgroundRefresh(SampleData data) : IHostedService, IDisposable
{
	private readonly SampleData _data = data;
	private Timer?_timer;

	public Task StartAsync(CancellationToken cancellationToken)
	{
		_timer = new Timer(AddToCache, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
		return Task.CompletedTask;
	}

	private void AddToCache(object? state)
	{
		_data.Data.Add($"The new data was added at {DateTime.Now.ToLocalTime()}");
	}

	public Task StopAsync(CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public void Dispose()
	{
		throw new NotImplementedException();
	}
}
