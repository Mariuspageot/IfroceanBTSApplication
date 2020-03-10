using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace projetWPF2
{
    class DAOPersonne
    {
        public int idDAOPersonne;
        public string nomDAOPersonne;
        public string prenomDAOPersonne;
        public int groupeDAOPersonne;
        public string passwdDAOPersonne;

        public DAOPersonne(int idPersonneDAO, string nomPersonneDAO, string prenomPersonneDAO, int groupeDAOPersonne, string passwd)
        {
            idDAOPersonne = idPersonneDAO;
            nomDAOPersonne = nomPersonneDAO;
            prenomDAOPersonne = prenomPersonneDAO;
            this.groupeDAOPersonne = groupeDAOPersonne;
            passwdDAOPersonne = passwd;
        }
        public DAOPersonne(string nomPersonneDAO, string prenomPersonneDAO, int groupeDAOPersonne, string passwd)
        {
            nomDAOPersonne = nomPersonneDAO;
            prenomDAOPersonne = prenomPersonneDAO;
            this.groupeDAOPersonne = groupeDAOPersonne;
            passwdDAOPersonne = passwd;
        }
        public static ObservableCollection<DAOPersonne> listePersonnes()
        {
            ObservableCollection<DAOPersonne> l = DALPersonne.selectPersonnes();
            return l;
        }

        public static DAOPersonne getPersonne(int idPersonne)
        {
            DAOPersonne p = DALPersonne.getPersonne(idPersonne);
            return p;
        }

        public static void updatePersonne(PersonneViewModel p)
        {
            DALPersonne.updatePersonne(new DAOPersonne(p.idPersonneProperty, p.nomPersonneProperty, p.prenomPersonneProperty, p.idGroupeProperty,p.passwdPersonneProperty));
        }

        public static void supprimerPersonne(PersonneViewModel personne)
        {
            DALPersonne.supprimerPersonne(personne.idPersonneProperty);
        }

        public static void insertPersonne(PersonneViewModel p)
        {
            DALPersonne.insertPersonne(new DAOPersonne(p.nomPersonneProperty, p.prenomPersonneProperty, p.idGroupeProperty,p.passwdPersonneProperty));
        }
    }
}
