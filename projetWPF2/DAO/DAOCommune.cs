using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class DAOCommune
    {
        public int idDAOCommune;
        public string nomDAOCommune;
        public int idDepartementDAOCommune;

        public DAOCommune(int id,string nom, int idDep)
        {
            idDAOCommune = id;
            nomDAOCommune = nom;
            idDepartementDAOCommune = idDep;
        }
        public DAOCommune( string nomCommune, int idCommune)
        {
            this.idDAOCommune = idCommune;
            this.nomDAOCommune = nomCommune;
        }
        public static DAOCommune getCommune(int idCommune)
        {
            DAOCommune commune = DALCommune.getCommune(idCommune);
            return commune;
        }
        public static void updateCommune(CommuneViewModel c)
        {
            DALCommune.updateCommune(new DAOCommune( c.idCommuneProperty,c.nomCommuneProperty,c.departement.idDepartementProperty));
        }
        public static ObservableCollection<DAOCommune> listeCommune()
        {
            ObservableCollection<DAOCommune> l = DALCommune.selectCommune();
            return l;
        }
        public static void insertCommune(CommuneViewModel c)
        {
            DALCommune.insertCommune(new DAOCommune(c.nomCommuneProperty, c.departement.idDepartementProperty));
        }
        public static void deleteCommune(int id)
        {
            DALCommune.supprimerCommune(id);
        }
    }
}
