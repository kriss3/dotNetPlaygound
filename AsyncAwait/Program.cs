using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using static System.Console;

namespace AsyncAwait;

class Program
{
    public static async Task Main(string[] args)
    {
        DoAsync dc = new();
        await dc.RunDownloadSync();
        ReadLine();
    }
}


class DoAsync 
{
    public async Task RunDownloadSync()
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

    private static IEnumerable<string> PrepData()
    {
        List<string> output = new List<string>
        {
            "http://www.yahoo.com",
            "http://www.google.com",
            "http://www.microsoft.com",
            "http://www.cnn.com",
            "http://www.codeproject.com",
            "http://www.stackoverflow.com"
        };

        return output;
    }

}
