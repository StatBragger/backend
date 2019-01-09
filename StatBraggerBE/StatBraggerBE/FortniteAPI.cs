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
                        player.s7SoloWins = this.data.stats.p2.top1.displayValue;
                        player.s7SoloScore = this.data.stats.p2.score.displayValue;
                        player.s7SoloTop10 = this.data.stats.p2.top10.displayValue;
                        player.s7SoloTop25 = this.data.stats.p2.top25.displayValue;
                        player.s7SoloKD = this.data.stats.p2.kd.displayValue;
                        player.s7SoloWinRatio = this.data.stats.p2.winRatio.displayValue;
                        player.s7SoloTotalMatches = this.data.stats.p2.matches.displayValue;
                        player.s7SoloKills = this.data.stats.p2.kills.displayValue;
                        player.s7SoloKPG = this.data.stats.p2.kpg.displayValue;
                        player.s7SoloScorePerMatch = this.data.stats.p2.scorePerMatch.displayValue;
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

        public string s7SoloScore { get; set; }
        public string s7SoloWins { get; set; }
        public string s7SoloTop10 { get; set; }
        public string s7SoloTop25 { get; set; }
        public string s7SoloKD { get; set; }
        public string s7SoloWinRatio { get; set; }
        public string s7SoloTotalMatches { get; set; }
        public string s7SoloKills { get; set; }
        public string s7SoloKPG { get; set; }
        public string s7SoloScorePerMatch { get; set; }

        override
        public string ToString()
        {
            return "\n\n\nAccount ID: " + accountID + "\nEpic name: "
                + epicUserHandle + "\nPlatform: " + platformNameLong +
                "\n\n\nSeason 7\n----------------------------\n\nSolo Total Score: " + s7SoloScore +
                "\n\nSolo Wins: " + s7SoloWins + "\nSolo Top 10: " + s7SoloTop10 + "\nSolo Top 25: "
                + s7SoloTop25 + "\n\nSolo Kills: " + s7SoloKills + "\nSolo K/D: " + s7SoloKD + "\nSolo Average Kills Per Game: " + s7SoloKPG + 
                "\n\nSolo Total Matches: " + s7SoloTotalMatches + "\nSolo Average Score Per Match: "
                + s7SoloScorePerMatch + "\nSolo Win Ratio: " + s7SoloWinRatio;
        }
    }
}
