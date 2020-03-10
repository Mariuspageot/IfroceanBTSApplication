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
    /// Interaction logic for PageEquipe.xaml
    /// </summary>
    public partial class PageEquipe : Page
    {
        ObservableCollection<EquipeViewModel> ld;
        List<PersonneViewModel> lp;
        DALEquipe e = new DALEquipe();
        DALPersEquipe pe = new DALPersEquipe();
        DALPersonne p = new DALPersonne();
        DALGroupe g = new DALGroupe();
        public PageEquipe()
        {
            InitializeComponent();
            lp = new List<PersonneViewModel>();
            ld = EquipeORM.listeEquipes();
            listeEquipes.ItemsSource = ld;
            listePersonnes.ItemsSource = lp;
            listeAutre.ItemsSource = PersonneORM.listePersonnes();
        }


        private void supprimer_equipe(object sender, RoutedEventArgs e)
        {
            try 
            {
                EquipeORM.deleteEquipe((EquipeViewModel)listeEquipes.SelectedItem);
                listeEquipes.ItemsSource = EquipeORM.listeEquipes();
            }
            catch { }
        }

        private void AddEquipe_Click(object sender, RoutedEventArgs e)
        {
            EquipeORM.ajouterEquipe(new EquipeViewModel(nomEquipeTextBox.Text));
            listeEquipes.ItemsSource = EquipeORM.listeEquipes();
            nomEquipeTextBox.Clear();
        }
        private void retour_back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void supprimerPersonne(object sender, RoutedEventArgs e)
        {
            EquipeORM.deletePersonne((PersonneViewModel)listePersonnes.SelectedItem,(EquipeViewModel)listeEquipes.SelectedItem);
            listePersonnes.ItemsSource = PersEquipeORM.getPersonnes((EquipeViewModel)listeEquipes.SelectedItem);
        }

        private void Ajouter_Personne(object sender, RoutedEventArgs e)
        {
            try
            {
                EquipeORM.ajouterPersonne((PersonneViewModel)listeAutre.SelectedItem, (EquipeViewModel)listeEquipes.SelectedItem);
                listePersonnes.ItemsSource = PersEquipeORM.getPersonnes((EquipeViewModel)listeEquipes.SelectedItem);
            }
            catch { }
        }

        private void listeEquipe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listePersonnes.ItemsSource = PersEquipeORM.getPersonnes((EquipeViewModel)listeEquipes.SelectedItem);
        }
    }
}
