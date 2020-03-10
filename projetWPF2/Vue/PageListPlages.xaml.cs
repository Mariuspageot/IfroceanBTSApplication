using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace projetWPF2
{
    /// <summary>
    /// Interaction logic for PageListPlages.xaml
    /// </summary>
    public partial class PageListPlages : Page
    {
        ObservableCollection<PlageViewModel> lp;
        DALDepartement d = new DALDepartement();
        DALCommune c = new DALCommune();
        DALPlage p = new DALPlage();
        public PageListPlages()
        {
            InitializeComponent();
            // LIEN AVEC LA DAL
            // DALConnection.OpenConnection(); // Connectin BDD MySQL

            // Initialisation de la liste des personnes via la BDD.
            lp = PlageORM.listePlage();
            //grp = GroupeORM.getGroupe();

            //LIEN AVEC la VIEW
            listePlages.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
            // this.DataContext = lp; // bind de la liste avec la source, permettant le binding mais de façon globale sur toute la fenetre
        }

        private void Retour_back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Supprimer(object sender, RoutedEventArgs e)
        {
            PlageViewModel p = (PlageViewModel)listePlages.SelectedItem;
            lp.Remove(p);
            PlageORM.supprimerPlage(p);
            listePlages.ItemsSource = lp;
        }

        private void Ajouter_plage(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageAddPlage());
        }
    }
}
