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
    /// Interaction logic for PageListPersonne.xaml
    /// </summary>
    public partial class PageListPersonne : Page
    {

        ObservableCollection<PersonneViewModel> lp;
        DALPersonne c = new DALPersonne();
        DALGroupe g = new DALGroupe();

        public PageListPersonne()
        {
            InitializeComponent();
            // LIEN AVEC LA DAL
            // DALConnection.OpenConnection(); // Connectin BDD MySQL

            // Initialisation de la liste des personnes via la BDD.
            lp = PersonneORM.listePersonnes();
            //grp = GroupeORM.getGroupe();

            //LIEN AVEC la VIEW
            listePersonnes.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
            // this.DataContext = lp; // bind de la liste avec la source, permettant le binding mais de façon globale sur toute la fenetre
        }




        private void GoAddPersonne_Click(object sender, RoutedEventArgs e)
        {
            PageAddPersonne addP = new PageAddPersonne();
            this.NavigationService.Navigate(addP);     
        }

        private void Retour_click(object sender, RoutedEventArgs e)
        {
            PageMenu addP = new PageMenu();
            this.NavigationService.Navigate(addP);
        }

        private void supprimerButton_Click(object sender, RoutedEventArgs e)
        {
            PersonneViewModel toRemove = (PersonneViewModel)listePersonnes.SelectedItem;
            lp.Remove(toRemove);
            listePersonnes.Items.Refresh();
            PersEquipeORM.supprimerPersonne(toRemove);
            PersonneORM.deletePersonne(toRemove);
        }
    }
}
