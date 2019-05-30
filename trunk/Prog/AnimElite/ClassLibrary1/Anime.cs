using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Metier
{
    /// <summary>
    /// Classe qui comportera les caractéristiques d'un anime
    /// et qui seront affichés sur l'application
    /// </summary>
    [DataContract]
    public class Anime
    {
        [DataMember]
        public string Nom { get; private set; }
        [DataMember]
        public string Description { get; private set; }
        [DataMember]
        public bool Favori { get; private set; }
        [DataMember]
        public string Url { get; private set; }
        [DataMember]
        public List<string> ListeGenres { get; private set; }
        [DataMember]
        public string ImagePath { get; private set; }
        [DataMember]
        public string Type { get; private set; }
        [DataMember]
        public string Episode { get; private set; }
        [DataMember]
        public string DateDeParution { get; private set; }

        private HtmlAgilityPack.HtmlDocument htmlDoc { get; set; }

        public ObservableCollection<Commentaire> UserComments { get; set; }

        /// <summary>
        /// Constructeur de la classe Anime.
        /// Possibilité d'enlever certains paramètres et de récuperer les infos sur internet.
        /// </summary>
        public Anime(string nom)
        {
            Nom = nom;

            try
            {
                Url = "https://www.anime-planet.com/anime/" + URLFriendlyName();
                htmlDoc = ParsingInit();
                Description = GetDescriptionFromUrl();
                ImagePath = GetImagePath();
                Favori = false;
                ListeGenres = GetListOfGenres();
                //sépare les 2 infos 
                string info = GetTypeEtEpisode();
                Type = info.Split('(')[0];
                Episode = info.Split('(')[1].Replace(")", "");
                DateDeParution = GetPublishingYear();
                UserComments = new ObservableCollection<Commentaire>();
            }
            catch (System.NullReferenceException)
            {
                throw new System.NullReferenceException();
            }
        }

        /// <summary>
        /// Cette fonction permet de rajouter ou d'enlever un anime 
        /// dans la liste des favoris.
        /// Le texte retourné pourra être utilisé pour afficher une pop-up à l'écran pour informer l'utilisateur
        /// </summary>
        public string ChangerEtatFavori(Manager m)
        {
            string s;
            if (!Favori)
            {
                s = $"Wow {Nom} est mis en favori!";
                m.ListeAnimeFavori.Add(this); //Rajoute l'anime à la liste de favoris de l'utilisateur
            }
            else
            {
                s = $"Wow {Nom} n'est plus en favori!";
                m.ListeAnimeFavori.Remove(this); //On l'enlève cette fois
            }
            Favori = !Favori;
            return s;
        }
        /// <summary>
        /// Cette fonction prends le nom de l'anime et le convertit en chaine de caractères
        /// pour faciliter la recherche de l'anime sur internet
        /// </summary>
        /// <returns>Le nom de l'anime, ou les espaces sont remplacés par des %20</returns>
        private string URLFriendlyName()
        {
            StringBuilder newString = new StringBuilder();
            foreach (char c in Nom.ToCharArray())
            {
                switch (c)
                {
                    case ' ':
                        newString.AppendFormat("-");
                        break;
                    default:
                        newString.AppendFormat(c.ToString());
                        break;
                }
            }
            return newString.ToString();
        }


        private List<string> GetListOfGenres()
        {
            List<string> listeGenres = new List<string>();
            foreach (var node in htmlDoc.DocumentNode.SelectNodes("//*[@itemprop=\"genre\"]/a"))
            {
                if (Enum.IsDefined(typeof(Genre), node.InnerText))
                {
                    listeGenres.Add(node.InnerText);
                }
            }
            return listeGenres;
        }

        private string GetPublishingYear()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(htmlDoc.DocumentNode.SelectSingleNode("//*[@itemprop=\"datePublished\"]/a").InnerText);
            try
            {
                sb.AppendFormat(" - " + htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"iconYear\"]/a").InnerText);
            }
            catch (Exception)
            {
                return sb.ToString();
            }
            return sb.ToString();
        }

        private string GetImagePath()
        {
            WebClient web = new WebClient();
            string imageAddress = "Aucune URL trouvée";
            string path = "../../Image/AnimePics/" + URLFriendlyName() + ".png";
            var node = htmlDoc.DocumentNode.SelectSingleNode("//*[@itemprop=\"image\"]").OuterHtml;
            foreach (string s in node.Split('"'))
            {
                if (s.Contains("anime"))
                {
                    imageAddress = s;
                    break;
                }
            }
            if(!(imageAddress.Equals("Aucune URL trouvée")) && !(File.Exists(path)))
            {
                web.DownloadFile("https://www.anime-planet.com" + imageAddress, path);
                web.Dispose();
            }
            return "Image/AnimePics/"+URLFriendlyName()+".png";
        }

        private HtmlAgilityPack.HtmlDocument ParsingInit()
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            try
            {
                htmlDoc = web.Load(Url);
            }
            catch (SystemException)
            {
                throw new System.NullReferenceException();
            }
            return htmlDoc;
        }

        /// <summary>
        /// Cette méthode récupère la description d'un anime, ou indique qu'il n'y en  pas
        /// si celle-ci est manquante. Elle récupère aussi le vrai nom de l'anime, pour pouvoir améliorer
        /// la qualité du logiciel
        /// </summary>
        /// <param name="url">L'url de l'anime, trouvée dans la méthode SearchForAnime</param>
        /// <returns>La description de l'anime, ou un message si il n'y en a pas</returns>
        private string GetDescriptionFromUrl()
        {
            string default_Description = "Aucune description n'est disponible pour le moment";
            try
            {
                string description = htmlDoc.DocumentNode.SelectSingleNode("//*[@itemprop=\"description\"]").InnerText;
                //remplace les caractère pas beau par des truc compréhensible
                return description.Replace("&mdash;", "-").Replace("&quot;", "\"").Replace("&#039;", "'").Replace("&hellip;", "...");
            }
            catch (System.NullReferenceException)
            {
                return default_Description;
            }
        }
        //récupere les information concernant le type et les caratéristique des épisodes
        private string GetTypeEtEpisode()
        {
            return htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"type\"]").InnerText;
        }
       

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (this.GetType() != obj.GetType()) return false;
            return base.Equals(obj as Anime);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool Equals(Anime a)
        {
            return a.Nom == this.Nom && a.Description == this.Description;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Nom : "+Nom);
            sb.AppendFormat("\nDescription :  \n" + Description);
            sb.AppendFormat("\nGenres : " + ListeGenres);
            return sb.ToString();
        }
       
    }
}
