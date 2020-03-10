using System.Collections.ObjectModel;

namespace projetWPF2
{
    public class DAOPersEquipe
    {
        public int idPersonneDAOPersEquipe;
        public int idEquipeDAOPersEquipe;

        public DAOPersEquipe(int idPersonne, int idEquipe)
        {
            this.idPersonneDAOPersEquipe = idPersonne;
            this.idEquipeDAOPersEquipe = idEquipe;


        }
        public static ObservableCollection<DAOPersEquipe> listePersEquipes()
        {
            ObservableCollection<DAOPersEquipe> l = DALPersEquipe.selectPersEquipes();
            return l;
        }

        public static DAOPersEquipe getPersEquipe(int id)
        {
            DAOPersEquipe p = DALPersEquipe.getPersonneEquipe(id);
            return p;
        }

        public static void updatePersEquipe(PersonneViewModel p, EquipeViewModel e)
        {
            DALPersEquipe.updatePersEquipe(p,e);
        }
        public static void supprimerEquipe(EquipeViewModel e)
        {
            DALPersEquipe.supprimerEquipe(e);
        }

        public static void supprimerPersEquipe(PersonneViewModel p, EquipeViewModel e)
        {
            DALPersEquipe.supprimerPersonneEquipe(p, e);
        }

        public static void insertPersEquipe(PersonneViewModel p, EquipeViewModel e)
        {
            DALPersEquipe.insertPersonneEquipe(p,e);
        }
        public static void supprimerPersonne(PersonneViewModel personne)
        {
            DALPersEquipe.supprimerPersonne(personne);
        }
    }
}