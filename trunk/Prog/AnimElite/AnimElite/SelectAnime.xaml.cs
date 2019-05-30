using Metier;
using System;
using System.Collections;
using System.Collections.Generic;
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
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class SelectAnime : UserControl
    {
        Manager m = new Manager();



        public string nomListe
        {
            get { return (string)GetValue(nomListeProperty); }
            set { SetValue(nomListeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for nomListe.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty nomListeProperty =
            DependencyProperty.Register("nomListe", typeof(string), typeof(SelectAnime), new PropertyMetadata(null));



        public List<string> ListeAnimeParNom
        {
            get { return (List<string>)GetValue(ListeAnimeParNomProperty); }
            set { SetValue(ListeAnimeParNomProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ListeAnimeParNom.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ListeAnimeParNomProperty =
            DependencyProperty.Register("ListeAnimeParNom", typeof(List<string>), typeof(SelectAnime), new PropertyMetadata(null));




        public SelectAnime(char c)
        {
            nomListe = "Liste d'Anime commencant par " + c;
            InitializeComponent();
            ListeAnimeParNom = new List<string>();
            foreach(KeyValuePair<string,Anime> entry in m.ListeAnime)
            {
                if(entry.Key.First() == c )
                {
                    ListeAnimeParNom.Add(entry.Key);
                }
            }
            DataContext = this;
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PageAnime pageAnime = new PageAnime(Liste.SelectedItem.ToString());
            this.Content = pageAnime;
        }
    }
}
