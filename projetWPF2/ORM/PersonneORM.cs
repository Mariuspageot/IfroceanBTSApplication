using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    public class PersonneORM
    {

        public static PersonneViewModel getPersonne(int id)
        {
            DAOPersonne pDAO = DAOPersonne.getPersonne(id);
            int idGroupe = pDAO.groupeDAOPersonne;
            GroupeViewModel g = GroupeORM.getGroupe(idGroupe);
            PersonneViewModel p = new PersonneViewModel(pDAO.idDAOPersonne, pDAO.nomDAOPersonne, pDAO.prenomDAOPersonne, g,pDAO.passwdDAOPersonne);

            return p;
        }

        public static ObservableCollection<PersonneViewModel> listePersonnes()
        {
            ObservableCollection<DAOPersonne> lDAO = DAOPersonne.listePersonnes();
            ObservableCollection<PersonneViewModel> l = new ObservableCollection<PersonneViewModel>();
            foreach (DAOPersonne element in lDAO)
            {
                int idGroupe = element.groupeDAOPersonne;

                GroupeViewModel g = GroupeORM.getGroupe(idGroupe); // Plus propre que d'aller chercher le métier dans la DAO.
                PersonneViewModel p = new PersonneViewModel(element.idDAOPersonne, element.nomDAOPersonne, element.prenomDAOPersonne, g,element.passwdDAOPersonne);
                l.Add(p);
            }
            return l;
        }
        public static PersonneViewModel connexion(string name, string pass)
        {
            ObservableCollection<DAOPersonne> lDAO = DAOPersonne.listePersonnes();
            PersonneViewModel personne = null;
            foreach (DAOPersonne element in lDAO)
            {
                if (element.nomDAOPersonne == name && element.passwdDAOPersonne == pass)
                    personne = new PersonneViewModel(element.idDAOPersonne, element.nomDAOPersonne, element.prenomDAOPersonne, GroupeORM.getGroupe(element.groupeDAOPersonne), element.passwdDAOPersonne);
            }
            return personne;
        }
        public static void ajouterPersonne(PersonneViewModel personne)
        {
            DAOPersonne.insertPersonne(personne);
        }
        public static void deletePersonne(PersonneViewModel personne)
        {
            DAOPersonne.supprimerPersonne(personne);
        }
    }
}
