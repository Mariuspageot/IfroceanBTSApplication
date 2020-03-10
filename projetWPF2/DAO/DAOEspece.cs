using System.Collections.ObjectModel;

namespace projetWPF2
{
    public class DAOEspece
    {
        public int idDAOEspece;
        public string nomDAOEspece;

        public DAOEspece(int id, string nom)
        {
            idDAOEspece = id;
            nomDAOEspece = nom;
        }
        public DAOEspece(string nom)
        {
            nomDAOEspece = nom;
        }
        public static ObservableCollection<DAOEspece> listeEspeces()
        {
            ObservableCollection<DAOEspece> l = DALEspece.selectEspece();
            return l;
        }

        public static DAOEspece getEspece(int id)
        {
            DAOEspece p = DALEspece.getEspece(id);
            return p;
        }

        public static void updateEspece(EspeceViewModel p)
        {
            DALEspece.updateEspece(new DAOEspece(p.idEspeceProperty, p.nomEspeceProperty));
        }

        public static void supprimerEspece(EspeceViewModel espece)
        {
            DALEspece.supprimerEspece(espece.idEspeceProperty);
        }

        public static void insertEspece(EspeceViewModel p)
        {
            DALEspece.insertEspece(new DAOEspece(p.idEspeceProperty, p.nomEspeceProperty));
        }

    }
}