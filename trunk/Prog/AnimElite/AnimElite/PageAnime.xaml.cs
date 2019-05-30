using Metier;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimElite
{
    /// <summary>
    /// Logique d'interaction pour PageAnime.xaml
    /// </summary>
    public partial class PageAnime : UserControl
    {
        Manager m;

        public Anime anime
        {
            get { return (Anime)GetValue(animeProperty); }
            set
            {
                SetValue(animeProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for anime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty animeProperty =
            DependencyProperty.Register("anime", typeof(Anime), typeof(PageAnime), new PropertyMetadata(null));


        public bool RadioBtnCheck
        {
            get { return (bool)GetValue(RadioBtnCheckProperty); }
            set { SetValue(RadioBtnCheckProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RadioBtnCheck.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RadioBtnCheckProperty =
            DependencyProperty.Register("RadioBtnCheck", typeof(bool), typeof(PageAnime), new PropertyMetadata(false));
        
        //montre à l'utilisateur qu'il a mis l'anime en favori
        private void AjoutFavoris(object sender, RoutedEventArgs e)
        {
            anime.ChangerEtatFavori(m);
            if (anime.Favori)
            {
                AnimeName.Foreground = new SolidColorBrush(Colors.Red);
                IsFavori.Visibility = Visibility.Visible;
            }
            else
            {
                AnimeName.Foreground = new SolidColorBrush(Colors.Black);
                IsFavori.Visibility = Visibility.Hidden;
            }
            m.MettreEnCache(anime);
        }



        public PageAnime(string name)
        {
            InitializeComponent();
            try {
                
                m = new Manager();
                anime = LookForAnimeInDictionary(name);
                if (!(m.ListeCommentaire == null))
                {
                    foreach (KeyValuePair<string, ObservableCollection<Commentaire>> entry in m.ListeCommentaire)
                    {
                        if (entry.Key.Equals(anime.Nom))
                        {
                            anime.UserComments = entry.Value;
                            break;
                        }
                    }
                }
                if (anime.Favori)
                {
                    AnimeName.Foreground = new SolidColorBrush(Colors.Gold);
                    IsFavori.Visibility = Visibility.Visible;
                }
                else
                {
                    AnimeName.Foreground = new SolidColorBrush(Colors.DarkCyan);
                }

                m.MettreEnCache(anime);
                DataContext = anime;
            }
            catch (System.NullReferenceException)
            {
                ErrorHandling e = new ErrorHandling();
                this.Content = e;
            }
        }

        public Anime LookForAnimeInDictionary(string name)
        {
            foreach(KeyValuePair<string,Anime> entry in m.ListeAnime)
            {
                if (name.Equals(entry.Key) && entry.Value != null)
                {
                    entry.Value.UserComments = new ObservableCollection<Commentaire>();
                    return entry.Value;
                }
                    
            }
            try {
                return new Anime(name);
            }
            catch (System.NullReferenceException)
            {
                throw new System.NullReferenceException();
            }
        }
        
        //permet de récuperer le commentaire et le choix des radio box lorsque le bouton est cliqué
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Commentaire c = new Commentaire(CommentaireUtilisateur.Text, RadioBtnCheck);
            m.AjouterCommentaire(anime.Nom,c);
            anime.UserComments.Add(c);
        }
        //permet de vider la textBox la première fois cliqué puis ne s'éfface plus
        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }
    }
}
