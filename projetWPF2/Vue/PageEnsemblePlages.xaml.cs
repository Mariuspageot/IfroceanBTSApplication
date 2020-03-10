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
    /// Interaction logic for PageEnsemblePlages.xaml
    /// </summary>
    public partial class PageEnsemblePlages : Page
    {
        ObservableCollection<EnsemblesViewModel> ld;
        List<PlageViewModel> lp = new List<PlageViewModel>();
        ObservableCollection<PlageViewModel> lps;
        DALEnsembles e = new DALEnsembles();
        DALPlageEnsemble pe = new DALPlageEnsemble();
        DALPlage p = new DALPlage();
        DALCommune c = new DALCommune();
        DALDepartement d = new DALDepartement();
        public PageEnsemblePlages()
        {
            InitializeComponent();

            ld = EnsemblePlageORM.listeEnsembles();
            lps = PlageORM.listePlage();

            listePlages.ItemsSource = lps;
            listeEnsemble.ItemsSource = ld;
            listeEnsemblePlages.ItemsSource = lp;
        }


        private void supprimer_ensemble(object sender, RoutedEventArgs e)
        {
            try
            {
            EnsemblePlageORM.delete((EnsemblesViewModel)listeEnsemble.SelectedItem);
            listeEnsemble.ItemsSource = EnsemblePlageORM.listeEnsembles();
            }
            catch { }
        }

        private void retour_back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Ajouter_Plage(object sender, RoutedEventArgs e)
        {
            try
            {
                EnsemblePlageORM.ajouterPlage((EnsemblesViewModel)listeEnsemble.SelectedItem, (PlageViewModel)listePlages.SelectedItem);
                EnsemblesViewModel ensembles = (EnsemblesViewModel)listeEnsemble.SelectedItem;
                listeEnsemblePlages.ItemsSource = PlageEnsembleORM.getplages(ensembles);
            }
            catch { }
        }
        private void supprimerPlage(object sender, RoutedEventArgs e)
        {
            try
            {
            EnsemblePlageORM.deletePlage((EnsemblesViewModel)listeEnsemble.SelectedItem,(PlageViewModel)listeEnsemblePlages.SelectedItem);
            listeEnsemblePlages.ItemsSource = PlageEnsembleORM.getplages((EnsemblesViewModel)listeEnsemble.SelectedItem);
            }
            catch { }

        }

        private void listeEnsemblePlage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnsemblesViewModel es = (EnsemblesViewModel)listeEnsemble.SelectedItem;
            listeEnsemblePlages.ItemsSource = PlageEnsembleORM.getplages((EnsemblesViewModel)listeEnsemble.SelectedItem);
        }

        private void AddEnsemble_Click(object sender, RoutedEventArgs e)
        {
            EnsemblePlageORM.insertEnsemble(new EnsemblesViewModel(nomEnsembleTextBox.Text));
            listeEnsemble.ItemsSource = EnsemblePlageORM.listeEnsembles();
        }
    }
}
