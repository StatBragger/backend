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
using System.Threading;
using System.Diagnostics;

namespace StatBraggerBE
{
    class CallOfDutyAPI
    {
        private string game;
        private string username;
        private string platform;
        private string type;
        private string content;
        private dynamic data;

        public CallOfDutyAPI(string game, string username, string platform, string type)
        {
            this.game = game;
            this.username = username;
            this.platform = platform;
            this.type = type;
        }

        public async Task<CODPlayer> PullData()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync("https://cod-api.theapinetwork.com/api/stats/" + game + "/" + username + "/" + platform + "?type=" + type + ""))
                {
                    using (HttpContent content = response.Content)
                    {
                        this.content = await content.ReadAsStringAsync();
                        this.data = JObject.Parse(this.content);
                        CODPlayer player = new CODPlayer();
                        Console.WriteLine(this.content);
                        return player;
                    }
                }
            }
        }

        public CODPlayer getPlayer()
        {
            CODPlayer p = null;
            try
            {
                Task.Run(async () => { p = await PullData(); }).GetAwaiter().GetResult();
            }
            catch (Exception e)
            {
                Program.Main(null);
                return null;
            }

            return p;
        }
    }



    public class CODPlayer
    {

        override
        public string ToString()
        {
            //TOSTRING FOR TESTING PURPOSES ONLY
            return "";
        }
    }
}
