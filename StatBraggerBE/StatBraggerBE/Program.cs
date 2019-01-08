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
            Console.Write("Enter fortnite username: ");
            string name = Console.ReadLine();
            Console.Write("\nEnter platform (psn, xbl, pc): ");
            string platform = Console.ReadLine();

            FortniteAPI player = new FortniteAPI(name,platform);
            player.pullData();

            Console.ReadLine();
        }
    }
}
