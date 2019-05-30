using System.Text;
using System.Runtime.Serialization;

namespace Metier
{
    [DataContract]
    public class Commentaire
    {
        [DataMember]
        public string Comment { get; private set; }
        [DataMember]
        public bool Recommande { get; private set; }

        public Commentaire(string comment, bool recommandation)
        {
            Comment = comment;
            Recommande = recommandation;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            if (Recommande)
            {
                s.AppendFormat("L'utilisateur recommande, ");
            }
            else
            {
                s.AppendFormat("L'utilisateur ne recommande pas, ");
            }
            s.AppendFormat($"Et a laissé pour commentaire : {Comment}");
            return s.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (obj.GetType() != this.GetType()) return false;
            return base.Equals(obj as Commentaire);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool Equals(Commentaire c)
        {
            return c.Comment == this.Comment && c.Recommande == this.Recommande;
        }
    }
}
