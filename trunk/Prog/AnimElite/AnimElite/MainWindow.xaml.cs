using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace AnimElite
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public List<char> Alphabet
        {
            get { return (List<char>)GetValue(AlphabetProperty); }
            set { SetValue(AlphabetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Alphabet.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AlphabetProperty =
            DependencyProperty.Register("Alphabet", typeof(List<char>), typeof(MainWindow), new PropertyMetadata(null));

        public MainWindow()
        {
            InitializeComponent();
            // this.WindowStyle = WindowStyle.None;
            //Liste contenant les lettres de l'alphabet qui sont visible dans le master
            Alphabet = new List<char>
        {
            'A',
            'B',
            'C',
            'D',
            'E',
            'F',
            'G',
            'H',
            'I',
            'J',
            'K',
            'L',
            'M',
            'N',
            'O',
            'P',
            'Q',
            'R',
            'S',
            'T',
            'U',
            'V',
            'W',
            'X',
            'Y',
            'Z',
        };
            DataContext = this;
        }

        //permet d'accéder à la page des favoris ,fait apparaitre le bouton home
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Favoris page = new Favoris();
            Detail.Navigate(page);

            MenuPrincipal.Visibility = Visibility.Visible;

        }


        //permet d'accéder à la page des la selection avec en paramêtre la lettre sélectionné,fait apparaitre le bouton home

        private void Liste_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectAnime page = new SelectAnime((char)Liste.SelectedItem);
            Detail.Navigate(page);
            MenuPrincipal.Visibility = Visibility.Visible;
        }
        //ramène à la page d'accueil en cachant le bouton home
        private void Button_MenuPrincipal(object sender, RoutedEventArgs e)
        {
            Detail.Navigate(new Uri("MainMenu.xaml", UriKind.RelativeOrAbsolute));
            MenuPrincipal.Visibility = Visibility.Collapsed;


        }
        void Window_Closing(object sender, CancelEventArgs e)
        {
            SeeYouSpaceCowboy page = new SeeYouSpaceCowboy();

            Detail.Navigate(page);
            e.Cancel = false; // setting to true will not close the window
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            EndCard page = new EndCard();
            page.Show();
        }
    }
}
