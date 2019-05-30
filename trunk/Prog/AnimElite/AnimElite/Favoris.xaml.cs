using Metier;
using System;
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
    /// Logique d'interaction pour Page2.xaml
    /// </summary>
    public partial class Favoris : Page
    {
         private Manager manager;
         public Favoris()
         {
            manager = new Manager();
            InitializeComponent();
            DataContext = manager;
            textblock.Text = manager.AfficherCommentaire();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PageAnime page = new PageAnime((sender as Button).Content.ToString());
            this.Content = page;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            manager.ViderCache();
            textblock.Text = manager.AfficherCommentaire();
        }
    }
}
