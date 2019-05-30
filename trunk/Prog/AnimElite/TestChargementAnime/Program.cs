using Metier;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChargementAnime
{
    class Program
    {
        static void Main(string[] args)
        {
            string anime;
            Manager m = new Manager();
            foreach (KeyValuePair<string, Anime> entry in m.ListeAnime) {
                anime = entry.Key;
                Console.WriteLine(anime);
                if(!(m.ListeCommentaire is null))
                {
                    foreach (KeyValuePair<string, ObservableCollection<Commentaire>> entry2 in m.ListeCommentaire)
                    {
                        if (entry2.Key.Equals(anime))
                        {
                            foreach (Commentaire c in entry2.Value)
                            {
                                Console.WriteLine(c);
                            }
                        }
                    }
                }
            }
        }
    }
}
