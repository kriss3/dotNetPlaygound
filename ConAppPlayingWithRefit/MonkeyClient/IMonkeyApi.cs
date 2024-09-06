using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConAppPlayingWithRefit.MonkeyClient;
public interface IMonkeyApi
{
    [Get("/monkeydata.json")]
    Task<List<Monkey>> GetMonkeys();
}

