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
        static void Main(string[] args)
        {
            Console.Write("Enter FortNite username: ");
            string name = Console.ReadLine();
            Console.Write("\nEnter platform (psn, xbl, pc): ");
            string platform = Console.ReadLine();
            FortniteAPI player = new FortniteAPI(name, platform);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(player.getPlayer().ToString());
            Console.ReadLine();
        }
    }
}
