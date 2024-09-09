using ConAppPlayingWithRefit.Model;
using Refit;

namespace ConAppPlayingWithRefit.MonkeyClient;
public interface IMonkeyApi
{
    [Get("/monkeydata.json")]
    Task<List<Monkey>> GetMonkeys();

    [Post("/monkeys")]
    Task<Monkey> AddMonkey([Body] Monkey monkey);

    [Put("/monkeys/{id}")]
    Task UpdateMonkey(int id, [Body] Monkey monkey);

    [Delete("/monkeys/{id}")]
    Task DeleteMonkey(int id);
}

