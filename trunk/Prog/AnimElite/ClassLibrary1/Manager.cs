using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Manager
    {
        /// <summary>
        /// La clé de ce dictionaire sera la nom de l'anime ou se situe le commentaire,
        /// et la valeur sera le commentaire lui même.
        /// </summary>
        public Dictionary<string,ObservableCollection<Commentaire>> ListeCommentaire { get; private set; }

       /*Si l'utilisateur n'as pas encore visité l'anime, la valeur (Anime) associée à sa clé (string) sera null. 
        *Lorsque l'utilisateur visitera un anime, on verifie si la valeur est null.
        * Si elle l'est, on instancie la classe Anime,
        * Si elle ne l'est pas, on la charge.
        */
        public Dictionary<string, Anime> ListeAnime { get; private set; }
        public List<Anime> ListeAnimeFavori { get; private set; }

        public DataManager DManager { get; set; }

        public Manager()
        {
            ListeAnimeFavori = new List<Anime>();
            ListeAnime = new Dictionary<string, Anime>();
            DManager = new XMLDataManager();
            ListeAnime = DManager.LoadAnime();
            ListeCommentaire = DManager.LoadCommentaires();
            foreach(KeyValuePair<string,Anime> entry in ListeAnime)
            {
                if (entry.Value != null && entry.Value.Favori)
                {
                    ListeAnimeFavori.Add(entry.Value);
                }
            }
        }

        /// <summary>
        /// Cette fonction aura pour but de donner le pourcentage des recommandations sur tout les commentaires
        /// effectués par l'utilisateur.
        /// </summary>
        /// <returns>Un pourcentage représentant les recommandations</returns>
        private float GetMoyenneRecommandation()
        {
            int i = 0;
            int numberOfComments = 0;
            if (!(ListeCommentaire == null))
            {
                foreach (KeyValuePair<string, ObservableCollection<Commentaire>> entry in ListeCommentaire)
                {
                    foreach (Commentaire Commentaire in entry.Value)
                    {
                        if (Commentaire.Recommande) { i++; }
                        numberOfComments++;
                    }
                }
            }
            if(numberOfComments == 0) { return 0; }
            return ((float)i / (float)numberOfComments)*100;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Moyenne de recommandations positives : "+GetMoyenneRecommandation()+"%");
            if (!(ListeCommentaire == null))
            {
                int i = 0;
                int numberOfComments = 0;
                sb.AppendFormat("\nNombre de commentaires : ");
                foreach (KeyValuePair<string, ObservableCollection<Commentaire>> entry in ListeCommentaire)
                {
                    foreach (Commentaire Commentaire in entry.Value)
                    {
                        if (Commentaire.Recommande)
                            i++;
                        numberOfComments++;
                    }
                }
                sb.AppendFormat(numberOfComments.ToString());
            }
            if (ListeAnimeFavori.Count() == 0)
            {
                sb.AppendFormat("\nVous n'avez pas d'anime favori.");
            }
            else{
                sb.AppendFormat("\nNombre d'Animes Favoris : "+ ListeAnimeFavori.Count());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Affiche la liste des favoris de l'utilisateur
        /// Si l'utilisateur n'a pas de favoris, le logiciel l'indiquera
        /// </summary>
        /// <returns></returns>
        public string AfficherListeAnime()
        {
            StringBuilder s = new StringBuilder();
            if (ListeAnimeFavori.Count() == 0)
            {
                s.AppendFormat("L'utilisateur n'a pas de favoris!\n");
                return s.ToString();
            }
            s.AppendFormat("---------------------------------\n\nAnime Favoris :" + ListeAnimeFavori.Count() + "\n");
            foreach (Anime a in ListeAnimeFavori)
            {
                s.AppendFormat(a.ToString() + "\n");
            }
            s.AppendFormat("---------------------------------\n");
            return s.ToString();
        }
        /// <summary>
        /// méthode qui rend un string comprennant le nom de l'anime suivant de tous les commentaires de celui-ci
        /// </summary>
        /// /// <returns></returns>
        public string AfficherCommentaire()
        {
            StringBuilder commentaires = new StringBuilder();
            if (!(ListeCommentaire == null))
            {
                foreach (KeyValuePair<string, ObservableCollection<Commentaire>> entry in ListeCommentaire)
                {
                    //crée une liste remplie par le contenu de l'oversablecollection du dictionnaire
                    ObservableCollection<Commentaire> listeCom = new ObservableCollection<Commentaire>(entry.Value);
                    commentaires.AppendFormat(entry.Key + "\n");
                    foreach (Commentaire commentaire in listeCom)
                    {
                        commentaires.AppendFormat("\t" + commentaire.ToString() + "\n");
                    }
                }
            }
            return commentaires.ToString();
        }

        public void MettreEnCache(Anime a)
        {
            ListeAnime[a.Nom] = a;
            DManager.SaveAnime(ListeAnime);
        }

        public void AjouterCommentaire(string animeName ,Commentaire c)
        {
            if(ListeCommentaire == null) { ListeCommentaire = new Dictionary<string, ObservableCollection<Commentaire>>(); }
            if (!ListeCommentaire.ContainsKey(animeName))
            {
                ListeCommentaire.Add(animeName, new ObservableCollection<Commentaire>());
            }
            ListeCommentaire[animeName].Add(c);
            DManager.SaveCommentaire(ListeCommentaire);
        }

        public void ViderCache()
        {
            int i;
            for(i = 0; i < ListeAnime.Count; ++i)
            {
                if (ListeAnime.ElementAt(i).Value != null && !ListeAnime.ElementAt(i).Value.Favori)
                {
                    ListeAnime[ListeAnime.ElementAt(i).Key] = null;
                }
            }
            ListeCommentaire = null; 
            DManager.SaveAnime(ListeAnime);
            DManager.SaveCommentaire(ListeCommentaire);
        }

    }
}