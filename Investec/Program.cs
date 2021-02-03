using System;
using System.Collections.Generic;
using System.Linq;
namespace Investec
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVDownloader stringDownloader = new CSVDownloader();
            string url = @"http://prod.publicdata.landregistry.gov.uk.s3-website-eu-west-1.amazonaws.com/pp-monthly-update-new-version.csv";
            var rows = stringDownloader.DownlaodAsync(url).GetAwaiter().GetResult();

            Dictionary<string, PostCode> postCodes = new Dictionary<string, PostCode>();
            foreach (var row in rows)
            {
                if (!string.IsNullOrEmpty(row))
                {
                    var values = row.Split(',');
                    var price = int.Parse(values[1].Trim('"'));
                    var postcodeFull = values[3].Trim('"');
                    if (!string.IsNullOrEmpty(postcodeFull))
                    {
                        var postcode = postcodeFull.Substring(0, 4).Trim(); //first 4 didgets can have white spaces, trim white spaces
                        if (postCodes.TryGetValue(postcode, out PostCode item))
                            item.AddCost(price);
                        else
                            postCodes[postcode] = new PostCode { Code = postcode };
                    }
                    else
                    {
                        // add code to catch empty postcodes.
                    }
                }
            }

            var mostExpensiveCodes = postCodes.Values.OrderByDescending(x => 
            {
                return x.CostPerItem;
            }
            ).Take(10);

            foreach (var item in mostExpensiveCodes)
            {
                Console.WriteLine($"{item.Code} - {item.CostPerItem}");
            }
            Console.ReadKey();
        }
    }

    public class PostCode
    {
        public int Count { get; set; }
        public string Code { get; set; }
        public long Cost { get; set; }

        public long CostPerItem 
        { 
            get
            {
                if (Count > 0)
                {
                    return Cost / Count;
                }
                return 0;
            } 
        }

        public void AddCost(int cost)
        {
            Cost += cost;
            Count++;
        }
    }
}
