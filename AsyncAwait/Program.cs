using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

using static System.Console;

namespace AsyncAwait;

class Program
{
    public static async Task Main()
    {
        DoAsync __ = new();
        //await dc.RunDownloadSync();

        await DoAsync.GetMonkeysAsync();

        ReadLine();
    }
}


internal class DoAsync
{
    public static async Task<IEnumerable<Monkey>> GetMonkeysAsync()
    {
		return await LocalData.GetLocalMonkeys();
	}

    public static async Task RunDownloadSync()
    {
        var sites = PrepData();

        foreach (var site in sites)
        {
            WebsiteDataModel wdm = DownloadWebsite(site);
            await ReportWebsiteInfo(wdm);
        }

    }

    private static WebsiteDataModel DownloadWebsite(string site)
    {
        var wdm = new WebsiteDataModel();
        HttpClient wc = new();

        wdm.WebsiteUrl = site;
        wdm.WebsiteData = wc.GetAsync(site).Result.ToString();

        return wdm;
    }

    private async static Task ReportWebsiteInfo(WebsiteDataModel wdm)
    {
        await Task.Run(
            () => WriteLine($"{wdm.WebsiteUrl} downloaded: {wdm.WebsiteData.Length} characters long."));
    }

    private static List<string> PrepData()
    {
        List<string> output =
        [
            "http://www.yahoo.com",
            "http://www.google.com",
            "http://www.microsoft.com",
            "http://www.cnn.com",
            "http://www.codeproject.com",
            "http://www.stackoverflow.com"
        ];

        return output;
    }
}

public static class LocalData
{
    public static async ValueTask<IEnumerable<Monkey>> GetLocalMonkeys()
    {
        var baseUrl = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/MonkeysApp/";
        var options = new RestClientOptions(baseUrl);
        var client = new RestClient(options);
        var request = new RestRequest("monkeydata.json");

        var response = await client.ExecuteAsync<List<Monkey>>(request, default);

        IEnumerable<Monkey> result = [];
        if (response.IsSuccessStatusCode) 
        {
            result = response.Data;
        }

        return result;
    }
}

public record Monkey(
    string Name, 
    string Location, 
    string Details, 
    string Image, 
    int Population, 
    double Latitude, 
    double Longitude);