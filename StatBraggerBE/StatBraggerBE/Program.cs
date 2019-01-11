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

namespace StatBraggerBE
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter 1 for Fortnite or 2 for Call of Duty: ");
            int ans = Convert.ToInt32(Console.ReadLine());
            switch(ans)
            {
                case 1:
                    Fortnite();
                    break;
                case 2:
                    CallOfDuty();
                    break;
            }
        }
        public static void Fortnite()
        {
            Console.Clear();
            Console.Write("Enter FortNite username: ");
            string name = Console.ReadLine();
            Console.Write("\nEnter platform (psn, xbl, pc): ");
            string platform = Console.ReadLine();
            FortniteAPI player = new FortniteAPI(name, platform);

            Console.ForegroundColor = ConsoleColor.White;
            FortnitePlayer p = player.getPlayer();
            if (p != null)
            {
                Console.WriteLine(p.ToString());
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nPlayer not found!\n\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.ReadLine();
        }
        public static void CallOfDuty()
        {
            Console.Clear();
            string type = "";
            Console.WriteLine("Enter game name (bo4, bo3, wwii, iw): ");
            string game = Console.ReadLine();
            Console.WriteLine("\nEnter platform (psn, xbl, steam, bnet): ");
            string platform = Console.ReadLine();   
            Console.WriteLine("\nEnter username: ");
            string username = Console.ReadLine();
            if(game == "bo4")
            {
                Console.WriteLine("\nEnter gamemode type (multiplayer, blackout): ");
                type = Console.ReadLine();
            }
            CallOfDutyAPI player = new CallOfDutyAPI(game,username,platform,type);

            Console.ForegroundColor = ConsoleColor.White;
            CODPlayer p = player.getPlayer();
            if (p != null)
            {
                Console.WriteLine(p.ToString());
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nError, a field is incorrect!\n\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.ReadLine();
        }
    }
}
