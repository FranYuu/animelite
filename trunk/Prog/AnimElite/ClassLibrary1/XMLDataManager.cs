using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Metier
{
    public class XMLDataManager : DataManager
    {
        public Dictionary<string, Anime> LoadAnime()
        {
            Dictionary<string, Anime> dicoAnime;
            DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<string, Anime>));
            using(FileStream stream = File.OpenRead("../../Save/anime.xml"))
            {
                using (XmlDictionaryReader xmlDicoReader = XmlDictionaryReader.CreateBinaryReader(stream, XmlDictionaryReaderQuotas.Max))
                {
                    dicoAnime = serializer.ReadObject(xmlDicoReader) as Dictionary<string, Anime>;
                }
            }
            return dicoAnime;
        }

        public Dictionary<string, ObservableCollection<Commentaire>> LoadCommentaires()
        {
            Dictionary<string, ObservableCollection<Commentaire>> dicoCom;
            DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<string, ObservableCollection<Commentaire>>));
            using (FileStream stream = File.OpenRead("../../Save/commentaire.xml"))
            {
                using (XmlDictionaryReader xmlDicoReader = XmlDictionaryReader.CreateBinaryReader(stream,XmlDictionaryReaderQuotas.Max))
                {
                   dicoCom = serializer.ReadObject(xmlDicoReader) as Dictionary<string, ObservableCollection<Commentaire>>;
                }
            }
            return dicoCom;
        }

        public void SaveAnime(Dictionary<string, Anime> dicoAnime)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<string,Anime>));
            using(FileStream stream = File.Create("../../Save/anime.xml"))
            {
                using (XmlDictionaryWriter xmlDicoWriter = XmlDictionaryWriter.CreateBinaryWriter(stream))
                {
                    serializer.WriteObject(xmlDicoWriter, dicoAnime);
                }
            }
        }

        public void SaveCommentaire(Dictionary<string, ObservableCollection<Commentaire>> dicoCom)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<string, ObservableCollection<Commentaire>>));
            using (FileStream stream = File.Create("../../Save/commentaire.xml"))
            {
                using (XmlDictionaryWriter xmlDicoWriter = XmlDictionaryWriter.CreateBinaryWriter(stream))
                {
                    serializer.WriteObject(xmlDicoWriter, dicoCom);
                }
            }
        }
    }
}
