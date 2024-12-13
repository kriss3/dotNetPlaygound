using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace ConAppRedis.Extensions;

public static class DistributedCacheExtensions
{
    public static async Task SetRecordAsync<T>(this IDistributedCache cache, 
        string recordId, 
        T data, 
        TimeSpan? absoluteExpireTime = null, 
        TimeSpan? unusedExpirationTime = null) 
    {
        DistributedCacheEntryOptions options = new()
        {
            AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60),
            SlidingExpiration = unusedExpirationTime
        };

        var jsonData = JsonSerializer.Serialize(data);
        await cache.SetStringAsync(recordId, jsonData, options);
    }

    public static async Task<T?> GetRecordAsync<T>(this IDistributedCache cache, string recordId)
    {
        var jsonData = await cache.GetStringAsync(recordId);

        if (jsonData is null) 
            return default;
        return JsonSerializer.Deserialize<T>(jsonData);
    }
}
