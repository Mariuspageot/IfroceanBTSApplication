using System.Text.RegularExpressions;
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
    /// Interaction logic for PageAddPlage.xaml
    /// </summary>
    public partial class PageAddPlage : Page
    {
        DALPlage p = new DALPlage();
        DALCommune c = new DALCommune();
        DALDepartement d = new DALDepartement();
        ObservableCollection<CommuneViewModel> lc;
        public PageAddPlage()
        {
            InitializeComponent();

            lc = CommuneORM.listeCommune();
            listeCommunes.ItemsSource = lc;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Ajouter_une_plage(object sender, RoutedEventArgs e)
        {
            try
            {
            CommuneViewModel commune = (CommuneViewModel)listeCommunes.SelectedItem;
            PlageViewModel pl = new PlageViewModel(nomTextBox.Text, commune, Int32.Parse(supTextBox.Text));
            PlageORM.ajouterPlage(pl);
            this.NavigationService.Navigate(new PageListPlages());
            }
            catch { }

        }

        private void Retour_back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
