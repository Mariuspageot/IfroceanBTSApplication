using System.Collections.ObjectModel;

namespace projetWPF2
{
    internal class DAOEtudeEspece
    {
        public int idDAOEtudeEspece;
        public int nombreDAOEtudeEspece;
        public int idEspeceDAOEtudeEspece;
        public int idEtudeDAOEtudeEspece;

        public DAOEtudeEspece(int id, int nb, int idEspece,  int etude)
        {
            this.idDAOEtudeEspece = id;
            this.nombreDAOEtudeEspece = nb;
            this.idEspeceDAOEtudeEspece = idEspece;
            this.idEtudeDAOEtudeEspece = etude;

        }
        public DAOEtudeEspece( int nb, int idEspece, int etude)
        {
            this.nombreDAOEtudeEspece = nb;
            this.idEspeceDAOEtudeEspece = idEspece;
            this.idEtudeDAOEtudeEspece = etude;

        }
        public static ObservableCollection<DAOEtudeEspece> listeEtudeEspeces()
        {
            ObservableCollection<DAOEtudeEspece> l = DALEtudeEspece.selectEtudeEspece();
            return l;
        }

        public static DAOEtudeEspece getEtudeEspece(int id)
        {
            DAOEtudeEspece p = DALEtudeEspece.getEtudeEspece(id);
            return p;
        }

        public static void updateEtudeEspece(EtudeEspeceViewModel p)
        {
            DALEtudeEspece.updateEtudeEspece(new DAOEtudeEspece(p.idEtudeEspeceProperty, p.nombreProperty, p.idEspeceProperty, p.idEtudeProperty));
        }

        public static void supprimerEtudeEspece(EtudeEspeceViewModel etudeEspece)
        {
            DALEtudeEspece.supprimerEtudeEspece(etudeEspece.idEtudeEspeceProperty);
        }

        public static void insertEtudeEspece(EtudeEspeceViewModel p)
        {
            DALEtudeEspece.insertEtudeEspece(new DAOEtudeEspece( p.nombreProperty, p.idEspeceProperty, p.idEtudeProperty));
        }
    }
}