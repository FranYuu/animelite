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
            Manager user = new Manager();
            Commentaire UserComment = new Commentaire("Sé pah male aimedéair",true);
            Anime anime = new Anime("Cowboy Bebop");
            Commentaire UserComment2 = new Commentaire("C pah trë bi1 lel", false);
            Anime anime2 = new Anime("Darling In The FranXX");
            Anime anime3 = new Anime("Log Horizon");
            Console.WriteLine($"C'est un anime du nom de :{anime.Nom}\n");
            Console.WriteLine($"{anime}\n");
            Console.WriteLine($"{anime2}\n");
            Console.WriteLine(anime.ChangerEtatFavori(user) + "\n" + user.AfficherListeAnime());
            Console.WriteLine($"{anime}\n");
            Console.WriteLine(anime.ChangerEtatFavori(user) + "\n" + user.AfficherListeAnime());
            Console.WriteLine($"{anime}\n");
            Console.WriteLine(UserComment.Equals(new Commentaire("Sé pah male aimedéair", true)));
        }
    }
}
