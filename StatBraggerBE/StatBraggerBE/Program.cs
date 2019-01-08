using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace StatBraggerBE
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://api.fortnitetracker.com/v1/profile/pc/Tenor._.";
            GetRequest(url); 
            Console.ReadLine();
        }
        async static void GetRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("TRN-Api-Key", "8a6f583a-5d48-47f3-baa2-3ca659ed8eb5");
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        Console.WriteLine(mycontent);
                    }
                }   
            }
        }
    }
}
