using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace projetWPF2
{
    class EquipeORM
    {

        public static EquipeViewModel getEquipe(EquipeViewModel equipe)
        {
            DAOEquipe eDAO = DAOEquipe.getEquipe(equipe.idEquipeProperty);

            List<PersonneViewModel> lp =
                DAOPersEquipe.listePersEquipes()
                .Where(e => e.idEquipeDAOPersEquipe == equipe.idEquipeProperty)
                .Select(e => PersonneORM.getPersonne(e.idPersonneDAOPersEquipe)).ToList();

            EquipeViewModel eq = new EquipeViewModel(eDAO.idDAOEquipe,eDAO.nomDAOEquipe,lp);


            return eq;
        }

        public static ObservableCollection<EquipeViewModel> listeEquipes()
        {
            ObservableCollection<DAOEquipe> lDAO = DAOEquipe.listeEquipes();
            ObservableCollection<EquipeViewModel> l = new ObservableCollection<EquipeViewModel>();
            foreach (DAOEquipe element in lDAO)
            {
                EquipeViewModel p = new EquipeViewModel(element.idDAOEquipe, element.nomDAOEquipe);
                l.Add(p);
            }
            return l;
        }
        public static void ajouterEquipe(EquipeViewModel equipe)
        {
            DAOEquipe.insertEquipe(equipe);
        }
        public static void deleteEquipe(EquipeViewModel equipe)
        {
            DAOEquipe.supprimerEquipe(equipe);
        }
        public static void ajouterPersonne(PersonneViewModel personne, EquipeViewModel equipe)
        {
            DAOPersEquipe.insertPersEquipe(personne, equipe);
        }
        public static void deletePersonne(PersonneViewModel personne, EquipeViewModel equipe)
        {
            DAOPersEquipe.supprimerPersEquipe(personne, equipe);
        }
    }
}