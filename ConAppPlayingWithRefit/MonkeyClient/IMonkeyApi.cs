﻿using ConAppPlayingWithRefit.Model;
using Refit;

namespace ConAppPlayingWithRefit.MonkeyClient;
public interface IMonkeyApi
{
    [Get("/monkeydata.json")]
    Task<List<Monkey>> GetMonkeys();
}
