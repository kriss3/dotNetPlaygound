using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            DoAsync dc = new DoAsync();
            dc.RunDownloadSync();
            Console.ReadLine();
        }
    }


    class DoAsync 
    {
        public void RunDownloadSync()
        {
            var sites = PrepData();

            foreach (var site in sites)
            {
                WebsiteDataModel wdm = DownloadWebsite(site);
                ReportWebsiteInfo(wdm);
            }

        }

        private WebsiteDataModel DownloadWebsite(string site)
        {
            var wdm = new WebsiteDataModel();
            HttpClient wc = new HttpClient();

            wdm.WebsiteUrl = site;
            wdm.WebsiteData = wc.GetAsync(site).Result.ToString();

            return wdm;
        }

        private void ReportWebsiteInfo(WebsiteDataModel wdm)
        {
            Console.WriteLine($"{wdm.WebsiteUrl} downloaded: {wdm.WebsiteData.Length} characters long.");
        }

        private IEnumerable<string> PrepData()
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
}
