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
    /// Interaction logic for PageEspeces.xaml
    /// </summary>
    public partial class PageEspeces : Page
    {
        ObservableCollection<EspeceViewModel> ld;
        DALEspece e = new DALEspece();

        public PageEspeces()
        {
            InitializeComponent();

            ld = EspeceORM.listeEspeces();

            listeEspeces.ItemsSource = ld;
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void AddEspece_Click(object sender, RoutedEventArgs e)
        {
            EspeceORM.ajouterEspece(new EspeceViewModel(nomTextBox.Text));
            nomTextBox.Clear();
            listeEspeces.ItemsSource = EspeceORM.listeEspeces();
        }

        private void supprimer_Click(object sender, RoutedEventArgs e)
        {
            EspeceViewModel espece = (EspeceViewModel)listeEspeces.SelectedItem;
            EspeceORM.deleteEspece(espece);
            listeEspeces.ItemsSource = EspeceORM.listeEspeces();
        }
    }
}
