using Metier;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSauvergardeXML
{
    class Program
    {
        static void Main(string[] args)
        {
            StubDataManager stub = new StubDataManager();
            XMLDataManager xml = new XMLDataManager();
            Dictionary<string, Anime> listeAnime = new Dictionary<string, Anime>();
            Dictionary<string, ObservableCollection<Commentaire>> listeCom = new Dictionary<string, ObservableCollection<Commentaire>>();
            listeAnime = stub.LoadAnime();
            Console.WriteLine("Animes Recupérés à partir du STUB!");
            listeCom = stub.LoadCommentaires();
            Console.WriteLine("Commentaires Recupérés à partir du STUB!");
            xml.SaveAnime(listeAnime);
            Console.WriteLine("Animes sauvegardé dans le fichier xml!");
            xml.SaveCommentaire(listeCom);
            Console.WriteLine("Commentaires sauvegardé dans le fichier xml!");

            Console.WriteLine("Transfert fini!");


            Dictionary<string, Anime> listeAnime2 = xml.LoadAnime();
            foreach(KeyValuePair<string,Anime> entry in listeAnime2)
            {
                Console.WriteLine(entry.Key + "\n" + entry.Value);
            }
            Dictionary<string, ObservableCollection<Commentaire>> listeCom2 = xml.LoadCommentaires();
            foreach (KeyValuePair<string, ObservableCollection<Commentaire>> entry in listeCom2)
            {
                Console.WriteLine(entry.Key + "\n");
                foreach(Commentaire c in entry.Value)
                {
                    Console.WriteLine(c+"\n");
                }
            }
        }
    }
}
