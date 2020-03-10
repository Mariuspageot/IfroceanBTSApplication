using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class DAOPlage
    {
        public int idDAOPlage;
        public string nomDAOPlage;
        public int idCommuneDAOPlage;
        public int superficieDAOPlage;

        public DAOPlage(int id, string nom, int idCom, int supPlage)
        {
            idDAOPlage = id;
            nomDAOPlage = nom;
            idCommuneDAOPlage = idCom;
            superficieDAOPlage = supPlage;
        }
        public DAOPlage(string nomPlage, int idCom, int supPlage)
        {
            this.idCommuneDAOPlage = idCom;
            this.nomDAOPlage = nomPlage;
            this.superficieDAOPlage = supPlage;
        }
        public static DAOPlage getPlage(int idPlage)
        {
            DAOPlage plage = DALPlage.getPlage(idPlage);
            return plage;
        }
        public static void updatePlage(PlageViewModel p)
        {
            DALPlage.updatePlage(new DAOPlage( p.idPlageProperty,  p.nomPlageProperty,  p.Commune.idCommuneProperty,p.superficieProperty));
        }
        public static ObservableCollection<DAOPlage> listePlages()
        {
            ObservableCollection<DAOPlage> l = DALPlage.selectPlage();
            return l;
        }
        public static void supprimerPlage(int id)
        {
            DALPlage.supprimerPlage(id);
        }
        public static void insertPlage(PlageViewModel p)
        {
            DALPlage.insertPlage(new DAOPlage(p.nomPlageProperty, p.Commune.idCommuneProperty, p.superficieProperty));
        }
    }
}
