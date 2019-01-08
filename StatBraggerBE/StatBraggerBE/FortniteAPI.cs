using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace StatBraggerBE
{
    public class FortniteAPI
    {
        private string username;
        private string platform;
        private string content;

        public FortniteAPI(string username, string platform)
        {
            this.username = username;
            this.platform = platform;
        }

        public async void pullData()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("TRN-Api-Key", "8a6f583a-5d48-47f3-baa2-3ca659ed8eb5"); //Fortnite API Authorization and key
                using (HttpResponseMessage response = await client.GetAsync("https://api.fortnitetracker.com/v1/profile/"+platform+"/"+username+""))
                {
                    using (HttpContent content = response.Content)
                    {
                        this.content = await content.ReadAsStringAsync();
                        Console.WriteLine(this.content);
                    }
                }
            }
        }
        override
        public string ToString()
        {
            return this.content;
        }
    }
}
