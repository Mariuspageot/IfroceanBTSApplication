
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace projetWPF2
{
    /// <summary>
    /// Interaction logic for PageMenu.xaml
    /// </summary>
    public partial class PageMenu : Page
    {
        PersonneViewModel utilisateur;
        public PageMenu()
        {
            InitializeComponent();
        }
        public PageMenu(PersonneViewModel personne)
        {
            InitializeComponent();
            utilisateur = personne;
            if (utilisateur.idGroupeProperty != 1)
            {
            BtnEquipe.Background = Brushes.Gray;
                BtnEquipe.Click -= Equipe;
            BtnEspece.Background = Brushes.Gray;
                BtnEspece.Click -= Especes;
            BtnPersonne.Background = Brushes.Gray;
                BtnPersonne.Click -= ListPersonnes;
            BtnEnsemble.Background = Brushes.Gray;
                BtnEnsemble.Click -= EnsemblePlages;
            BtnCommune.Background = Brushes.Gray;
                BtnCommune.Click -= ListCom;
            BtnPlage.Background = Brushes.Gray;
                BtnPlage.Click -= ListPlage;
            }
        }

        private void ListPersonnes(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new PageListPersonne());
        }

        private void ListDep(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageListDepartements());
        }

        private void ListCom(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageListCommune());
        }

        private void ListPlage(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageListPlages());
        }

        private void Equipe(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageEquipe());
        }

        private void Especes(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageEspeces());
        }

        private void EnsemblePlages(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageEnsemblePlages());
        }

        private void Etudes(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageEtude());
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
