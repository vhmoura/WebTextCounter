using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextCounterService;
using TextCounterService.Helpers;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var counter = new TextCounter();
            var res = counter.CountWords<Web>(@"http://www.loyalbooks.com/download/text/Railway-Children-by-E-Nesbit.txt");
            foreach (var d in res)
            {
                Console.WriteLine(string.Format("Word - '{0}' has appeared - '{1}' time(s) and the prime result is - '{2}'", d.Name, d.Count, d.IsPrime));
            }

            Console.ReadKey();
        }
    }
}
