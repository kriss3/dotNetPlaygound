namespace ConAppPlayingWithProxyPattern.Interfaces;
public interface IApiService
{
	Task<string> GetDataAsync(string url);
}
