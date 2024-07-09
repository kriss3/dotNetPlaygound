using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppPlayingWithRestSharp.Service;

public interface IApiService 
{
    Task<T> GetAsync<T>(string endpoint);
}
public class ApiService(IApiService apiService)
{

}
