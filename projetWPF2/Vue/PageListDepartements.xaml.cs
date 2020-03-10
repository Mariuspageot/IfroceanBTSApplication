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
    /// Interaction logic for PageListDepartements.xaml
    /// </summary>
    public partial class PageListDepartements : Page
    {
        ObservableCollection<DepartementViewModel> ld;
        DALPersonne c = new DALPersonne();
        DALGroupe g = new DALGroupe();
        DALDepartement d = new DALDepartement();
        public PageListDepartements()
        {
            InitializeComponent();
            // LIEN AVEC LA DAL
            // DALConnection.OpenConnection(); // Connectin BDD MySQL

            // Initialisation de la liste des personnes via la BDD.
            ld = DepartementORM.listeDepartement();
            //grp = GroupeORM.getGroupe();

            //LIEN AVEC la VIEW
            listeDepartements.ItemsSource = ld; // bind de la liste avec la source, permettant le binding.
            // this.DataContext = lp; // bind de la liste avec la source, permettant le binding mais de façon globale sur toute la fenetre
        }

        private void retour(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
