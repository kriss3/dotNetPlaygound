using ConAppPlayingWithRefit.Model;
using ConAppPlayingWithRefit.MonkeyClient;

namespace ConAppPlayingWithRefit.Service;
public class MonkeyService(IMonkeyApi monkeyApi)
{
    private readonly IMonkeyApi _monkeyApi = monkeyApi;

    public async Task<List<Monkey>> GetMonkeysAsync()
    {
        return await _monkeyApi.GetMonkeys();
    }

    public async Task AddMonkeyAsync(Monkey monkey)
    {
        await _monkeyApi.AddMonkey(monkey);
    }
}
