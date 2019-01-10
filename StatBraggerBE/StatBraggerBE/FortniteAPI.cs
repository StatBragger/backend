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
 Last update 1/10/2019
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
                        //Basic User Data
                        player.accountID = this.data.accountId;
                        player.epicUserHandle = this.data.epicUserHandle;
                        player.platformNameLong = this.data.platformNameLong;
                        //Lifetime Solo Stats
                        player.ltSoloWins = this.data.stats.p2.top1.displayValue;
                        player.ltSoloScore = this.data.stats.p2.score.displayValue;
                        player.ltSoloTop10 = this.data.stats.p2.top10.displayValue;
                        player.ltSoloTop25 = this.data.stats.p2.top25.displayValue;
                        player.ltSoloKD = this.data.stats.p2.kd.displayValue;
                        player.ltSoloWinRatio = this.data.stats.p2.winRatio.displayValue;
                        player.ltSoloTotalMatches = this.data.stats.p2.matches.displayValue;
                        player.ltSoloKills = this.data.stats.p2.kills.displayValue;
                        player.ltSoloKPG = this.data.stats.p2.kpg.displayValue;
                        player.ltSoloScorePerMatch = this.data.stats.p2.scorePerMatch.displayValue;
                        //Lifetime Duo Stats
                        player.ltDuoWins = this.data.stats.p10.top1.displayValue;
                        player.ltDuoScore = this.data.stats.p10.score.displayValue;
                        player.ltDuoTop5 = this.data.stats.p10.top5.displayValue;
                        player.ltDuoTop12 = this.data.stats.p10.top12.displayValue;
                        player.ltDuoKD = this.data.stats.p10.kd.displayValue;
                        player.ltDuoWinRatio = this.data.stats.p10.winRatio.displayValue;
                        player.ltDuoTotalMatches = this.data.stats.p10.matches.displayValue;
                        player.ltDuoKills = this.data.stats.p10.kills.displayValue;
                        player.ltDuoKPG = this.data.stats.p10.kpg.displayValue;
                        player.ltDuoScorePerMatch = this.data.stats.p10.scorePerMatch.displayValue;
                        //Lifetime Squad Stats
                        player.ltSquadWins = this.data.stats.p9.top1.displayValue;
                        player.ltSquadScore = this.data.stats.p9.score.displayValue;
                        player.ltSquadTop3 = this.data.stats.p9.top3.displayValue;
                        player.ltSquadTop6 = this.data.stats.p9.top6.displayValue;
                        player.ltSquadKD = this.data.stats.p9.kd.displayValue;
                        player.ltSquadWinRatio = this.data.stats.p9.winRatio.displayValue;
                        player.ltSquadTotalMatches = this.data.stats.p9.matches.displayValue;
                        player.ltSquadKills = this.data.stats.p9.kills.displayValue;
                        player.ltSquadKPG = this.data.stats.p9.kpg.displayValue;
                        player.ltSquadScorePerMatch = this.data.stats.p9.scorePerMatch.displayValue;

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
        //Basic User Data
        public string accountID { get; set; }
        public string platformNameLong { get; set; }
        public string epicUserHandle { get; set; }
        //Lifetime Solo Stats
        public string ltSoloScore { get; set; }
        public string ltSoloWins { get; set; }
        public string ltSoloTop10 { get; set; }
        public string ltSoloTop25 { get; set; }
        public string ltSoloKD { get; set; }
        public string ltSoloWinRatio { get; set; }
        public string ltSoloTotalMatches { get; set; }
        public string ltSoloKills { get; set; }
        public string ltSoloKPG { get; set; }
        public string ltSoloScorePerMatch { get; set; }
        //Lifetime Duo Stats
        public string ltDuoScore { get; set; }
        public string ltDuoWins { get; set; }
        public string ltDuoTop5 { get; set; }
        public string ltDuoTop12 { get; set; }
        public string ltDuoKD { get; set; }
        public string ltDuoWinRatio { get; set; }
        public string ltDuoTotalMatches { get; set; }
        public string ltDuoKills { get; set; }
        public string ltDuoKPG { get; set; }
        public string ltDuoScorePerMatch { get; set; }
        //Lifetime Squad Stats
        public string ltSquadScore { get; set; }
        public string ltSquadWins { get; set; }
        public string ltSquadTop3 { get; set; }
        public string ltSquadTop6 { get; set; }
        public string ltSquadKD { get; set; }
        public string ltSquadWinRatio { get; set; }
        public string ltSquadTotalMatches { get; set; }
        public string ltSquadKills { get; set; }
        public string ltSquadKPG { get; set; }
        public string ltSquadScorePerMatch { get; set; }

        override
        public string ToString()
        {
            //TOSTRING FOR TESTING PURPOSES ONLY
            return "\n\n\nAccount ID: " + accountID + "\nEpic name: "
                + epicUserHandle + "\nPlatform: " + platformNameLong +
                "\n\n\n\n------------------" +
                "\n|   LIFETIME     |\n------------------\n\n\n\n" +
                "SOLO\n----------------------\nTotal Score: " + ltSoloScore +
                "\n\nWins: " + ltSoloWins + "\nTop 10: " + ltSoloTop10 + "\nTop 25: "
                + ltSoloTop25 + "\nWin Percent: " + ltSoloWinRatio + "%\n\nKills: " 
                + ltSoloKills + "\nK/D: " + ltSoloKD + "\nAverage Kills Per Game: " + ltSoloKPG + 
                "\n\nTotal Matches: " + ltSoloTotalMatches + "\nAverage Score Per Match: "
                + ltSoloScorePerMatch +"\n\n\n\nDUO\n----------------------\nTotal Score: " + ltDuoScore +
                "\n\nWins: " + ltDuoWins + "\nTop 5: " + ltDuoTop5 + "\nTop 12: "
                + ltDuoTop12 + "\nWin Percent: " + ltDuoWinRatio + "%\n\nKills: "
                + ltDuoKills + "\nK/D: " + ltDuoKD + "\nAverage Kills Per Game: " + ltDuoKPG +
                "\n\nTotal Matches: " + ltDuoTotalMatches + "\nAverage Score Per Match: "
                + ltDuoScorePerMatch + "\n\n\n\nSQUAD\n----------------------\nTotal Score: " + ltSquadScore +
                "\n\nWins: " + ltSquadWins + "\nTop 3: " + ltSquadTop3 + "\nTop 6: "
                + ltSquadTop6 + "\nWin Percent: " + ltSquadWinRatio + "%\n\nKills: "
                + ltSquadKills + "\nK/D: " + ltSquadKD + "\nAverage Kills Per Game: " + ltSquadKPG +
                "\n\nTotal Matches: " + ltSquadTotalMatches + "\nAverage Score Per Match: "
                + ltSquadScorePerMatch;
        }
    }
}
