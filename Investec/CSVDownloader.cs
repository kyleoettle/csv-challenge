using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Investec
{
    public class CSVDownloader
    {

        public async Task<IEnumerable<string>> DownlaodAsync(string url)
        {
            string result;
            using (var client = new HttpClient())
            {

                var response = await client.GetAsync(url).ConfigureAwait(false);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return result.Split('\n');
                }
            }
            return null;

        }
    }
}
