using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace ConAppPlayingWithRefit.MonkeyClient;
public static class MonkeyApiFactory
{
    public static IMonkeyApi CreateMonkeyApi(IServiceProvider serviceProvider)
    {
        var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
        var httpClient = httpClientFactory.CreateClient("monkeyClient");
        return RestService.For<IMonkeyApi>(httpClient);
    }
}
