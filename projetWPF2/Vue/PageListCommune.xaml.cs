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
    /// Interaction logic for PageListCommune.xaml
    /// </summary>
    public partial class PageListCommune : Page
    {
        ObservableCollection<DepartementViewModel> ld;
        ObservableCollection<CommuneViewModel> lc;

        DALDepartement d = new DALDepartement();
        DALCommune c = new DALCommune();
        public PageListCommune()
        {
            InitializeComponent();
            ld = DepartementORM.listeDepartement();
            lc = CommuneORM.listeCommune();
            //LIEN AVEC la VIEW
            listeDeps.ItemsSource = ld;
            listeCommunes.ItemsSource = lc;

        }

        private void retour_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void AddCommune_Click(object sender, RoutedEventArgs e)
        {
            CommuneORM.insertCommune(new CommuneViewModel(nomTextBox.Text, (DepartementViewModel)listeDeps.SelectedItem));
            listeCommunes.ItemsSource = CommuneORM.listeCommune();
        }

        private void supprimerButton_Click(object sender, RoutedEventArgs e)
        {
            CommuneORM.supprimerCommune((CommuneViewModel)listeCommunes.SelectedItem);
            listeCommunes.ItemsSource = CommuneORM.listeCommune();
        }
    }
}
