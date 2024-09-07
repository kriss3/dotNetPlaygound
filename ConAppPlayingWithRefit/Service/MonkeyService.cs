using ConAppPlayingWithRefit.Model;
using ConAppPlayingWithRefit.MonkeyClient;

namespace ConAppPlayingWithRefit.Service;
public class MonkeyService(IMonkeyApi monkeyApi)
{
    private readonly IMonkeyApi _monkeyApi = monkeyApi;

    public async Task<List<Monkey>> GetMonkeys()
    {
        return await _monkeyApi.GetMonkeys();
    }
}
