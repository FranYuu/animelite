using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class StubDataManager : DataManager
    {
        public void SaveCommentaire(Dictionary<string, ObservableCollection<Commentaire>> listeCom)
        {
            throw new NotImplementedException();
        }

        public void SaveAnime(Dictionary<string, Anime> listeAnime)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string,ObservableCollection<Commentaire>> LoadCommentaires()
        {
            Dictionary<string, ObservableCollection<Commentaire>> listeCommentaire = new Dictionary<string, ObservableCollection<Commentaire>>();
            listeCommentaire.Add("Darling in the FranXX",
            new ObservableCollection<Commentaire>
            {
                new Commentaire("wow c trè le test",true),
                new Commentaire("lel",false),
                new Commentaire("oui",true),
            });
            return listeCommentaire;
        }

        public Dictionary<string, Anime> LoadAnime()
        {
            Dictionary<string, Anime> listeAnime = new Dictionary<string, Anime>();
            listeAnime.Add("Darling in the FranXX",null);
            listeAnime.Add("Kemono Friends",null);
            listeAnime.Add("Sword Art Online II",null);
            listeAnime.Add("Dagashi Kashi", null);
            listeAnime.Add("Devilman Crybaby",null);
            listeAnime.Add("Konosuba-Gods Blessing on this wonderful world", null);
            listeAnime.Add("Cowboy Bebop", null);
            listeAnime.Add("Miss kobayashis dragon maid", null);
            listeAnime.Add("Blend S", null);
            listeAnime.Add("Amagi Brilliant Park", null);
            listeAnime.Add("Jojos Bizarre Adventure 2012", null);
            listeAnime.Add("Jojos Bizarre Adventure Stardust Crusaders", null);
            listeAnime.Add("Jojos Bizarre Adventure Diamond is Unbreakable", null);
            listeAnime.Add("My Hero Academia", null);
            listeAnime.Add("My Hero Academia 2", null);
            listeAnime.Add("My Hero Academia 3", null);
            listeAnime.Add("Megalo box",null);
            listeAnime.Add("Ashita no Joe",null);
            listeAnime.Add("Persona 4 The Golden Animation", null);
            listeAnime.Add("Zoro",null);
            listeAnime.Add("Dragon Ball GT", null);
            listeAnime.Add("Persona 5 The Animation", null);
            listeAnime.Add("Persona 4 The Animation", null);
            listeAnime.Add("Oliver e Benji",null);
            listeAnime.Add("Saiki Kusuo no ψ-nan",null);
            listeAnime.Add("Tokyo ghoul", null);
            listeAnime.Add("Super Danganronpa 2 5 Komaeda Nagito to sekai no hakaisha", null);
            listeAnime.Add("A place Further than the Universe", null);
            listeAnime.Add("Danganronpa the Animation",null);
            listeAnime.Add("A Silent Voice", null);
            return listeAnime;
        }
    
    }
}