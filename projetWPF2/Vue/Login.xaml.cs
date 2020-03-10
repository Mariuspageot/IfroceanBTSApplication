using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace projetWPF2
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        DALPersonne p = new DALPersonne();
        DALGroupe g = new DALGroupe();
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connexion();
        }
        private void connexion()
        {
            PersonneViewModel personne = PersonneORM.connexion(login.Text, passwd.Password);
            if (personne != null)
            {
                MainWindow addP = new MainWindow(personne);
                addP.Show();
                this.Close();
            }
            else
                passwd.Password = "";
        }

        private void passwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return && e.Key != Key.Enter)
                return;
            e.Handled = true;
            connexion();
            
        }
    }
}
