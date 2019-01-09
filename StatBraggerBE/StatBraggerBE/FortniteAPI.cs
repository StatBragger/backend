using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Web;
/*
 Anthony Cittadino
 James Raynor
 Last update 1/9/2019
*/
namespace StatBraggerBE
{
    public class FortniteAPI
    {
        private string username;
        private string platform;
        private string content;
        private dynamic data;
        public FortniteAPI(string username, string platform)
        {
            this.username = username;
            this.platform = platform;
        }

        public async Task<Player> PullData()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("TRN-Api-Key", "8a6f583a-5d48-47f3-baa2-3ca659ed8eb5"); //Fortnite API Authorization and key
                using (HttpResponseMessage response = await client.GetAsync("https://api.fortnitetracker.com/v1/profile/" + platform + "/" + username + ""))
                {
                    using (HttpContent content = response.Content)
                    {
                        this.content = await content.ReadAsStringAsync();
                        this.data = JObject.Parse(this.content);
                        Player player = new Player();
                        player.accountID = this.data.accountId;
                        player.epicUserHandle = this.data.epicUserHandle;
                        player.platformNameLong = this.data.platformNameLong;
                        return player;
                    }
                }
            }
        }

        public Player getPlayer()
        {
            Player p = null;
            Task.Run(async () => { p = await PullData(); }).GetAwaiter().GetResult();
            return p;
        }
    }

  

    public class Player
    {
        public string accountID { get; set; }
        public string platformNameLong { get; set; }
        public string epicUserHandle { get; set; }

        override
        public string ToString()
        {
            return "\n\n\nAccount ID: " + accountID + "\nEpic name: "
                + epicUserHandle + "\nPlatform: " + platformNameLong;
        }
    }
}
