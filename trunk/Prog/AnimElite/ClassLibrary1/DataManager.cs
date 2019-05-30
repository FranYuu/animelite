using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{ 
    public interface DataManager
    {
        Dictionary<string,ObservableCollection<Commentaire>> LoadCommentaires();
        Dictionary<string,Anime> LoadAnime();
        void SaveCommentaire(Dictionary<string,ObservableCollection<Commentaire>> listeCom);
        void SaveAnime(Dictionary<string, Anime> listeAnime);
    }
}
