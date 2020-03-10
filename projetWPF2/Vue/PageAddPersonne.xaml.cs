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
    /// Interaction logic for PageAddPersonne.xaml
    /// </summary>
    public partial class PageAddPersonne : Page
    {

        PersonneViewModel myDataObject; // Objet de liaison
        DALPersonne c = new DALPersonne();
        DALGroupe g = new DALGroupe();
        ObservableCollection<GroupeViewModel> lg;

        public PageAddPersonne()
        {
            InitializeComponent();
            // LIEN AVEC LA DAL
            // DALConnection.OpenConnection(); // Connectin BDD MySQL

            // Initialisation de la liste des personnes via la BDD.
            //grp = GroupeORM.getGroupe();
            lg = GroupeORM.listeGroupes();

            //LIEN AVEC la VIEW

            listeGroupes.ItemsSource = lg;
            // this.DataContext = lp; // bind de la liste avec la source, permettant le binding mais de façon globale sur toute la fenetre
        }
        public void prenomChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject.prenomPersonneProperty = prenomTextBox.Text;

        }
        public void nomChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject.nomPersonneProperty = nomTextBox.Text;
        }

        private void AddPersonneClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (passwordTextBox.Password == passwordconfTextBox.Password)
                {
                    PersonneViewModel nouveau = new PersonneViewModel(nomTextBox.Text, prenomTextBox.Text, ((GroupeViewModel)listeGroupes.SelectedItem), passwordTextBox.Password);
                    PersonneORM.ajouterPersonne(nouveau);
                    PageListPersonne addP = new PageListPersonne();
                    this.NavigationService.Navigate(addP);
                }
            }
            catch { }
        }

        private void Retour_back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
