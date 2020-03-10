using System.Collections.ObjectModel;

namespace projetWPF2
{
    public class DAOEquipe
    {
        public int idDAOEquipe;
        public string nomDAOEquipe;

        public DAOEquipe(int id, string nom)
        {
            idDAOEquipe = id;
            nomDAOEquipe = nom;
        }
        public DAOEquipe(string nom)
        {
            nomDAOEquipe = nom;
        }
        public static ObservableCollection<DAOEquipe> listeEquipes()
        {
            ObservableCollection<DAOEquipe> l = DALEquipe.selectEquipe();
            return l;
        }

        public static DAOEquipe getEquipe(int id)
        {
            DAOEquipe p = DALEquipe.getEquipe(id);
            return p;
        }

        public static void updateEquipe(EquipeViewModel p)
        {
            DALEquipe.updateEquipe(new DAOEquipe(p.idEquipeProperty, p.nomEquipeProperty));
        }

        public static void supprimerEquipe(EquipeViewModel p)
        {
            DALEquipe.supprimerEquipe(new DAOEquipe(p.idEquipeProperty,p.nomEquipeProperty));
        }

        public static void insertEquipe(EquipeViewModel p)
        {
            DALEquipe.insertEquipe(new DAOEquipe(p.nomEquipeProperty));
        }

    }
}