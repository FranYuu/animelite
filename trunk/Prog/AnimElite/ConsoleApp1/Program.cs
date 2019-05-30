using Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRechercheAnime
{
    class Program
    {
        static void Main(string[] args)
        {
            Anime a = null;
            string name = Console.ReadLine();
            try
            {
                a = new Anime(name);
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Cet anime ne figure pas dans la basse de données du site, ou vous n'êtes pas connécté à internet :(");
            }
            Console.WriteLine(a);
        }
    }
}