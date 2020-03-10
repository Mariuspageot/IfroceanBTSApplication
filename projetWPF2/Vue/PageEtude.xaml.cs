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
    /// Interaction logic for PageEtude.xaml
    /// </summary>
    public partial class PageEtude : Page
    {
        ObservableCollection<EtudeViewModel> ld;
        ObservableCollection<EquipeViewModel> leq;
        ObservableCollection<EnsemblesViewModel> lep;
        DALEspece e = new DALEspece();
        DALEnsembles es = new DALEnsembles();
        DALEquipe eq = new DALEquipe();
        DALEtude ed = new DALEtude();
        DALEtudeEspece ee = new DALEtudeEspece();

        public PageEtude()
        {
            InitializeComponent();

            ld = EtudeORM.listeEtudes();
            leq = EquipeORM.listeEquipes();
            lep = EnsemblePlageORM.listeEnsembles();

            listeEtudes.ItemsSource = ld;
            listEnsembles.ItemsSource = lep;
            listEquipes.ItemsSource = leq;
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            PageMenu pageMenu = new PageMenu();
            this.NavigationService.GoBack();
        }

        private void AddEtude_Click(object sender, RoutedEventArgs e)
        {
            EtudeORM.insertEtude(titreTextBox.Text, (EnsemblesViewModel)listEnsembles.SelectedItem, (EquipeViewModel)listEquipes.SelectedItem);
        }

        private void supprimerEtude_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
