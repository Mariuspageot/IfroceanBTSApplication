using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class DAODepartement
    {
        public int idDepartement;
        public string nomDAODepartement;

        public DAODepartement(int idDep, string nomDep)
        {
            this.idDepartement = idDep;
            this.nomDAODepartement = nomDep;
        }
        public DAODepartement(string nomDep)
        {
            this.nomDAODepartement = nomDep;
        }
        public static ObservableCollection<DAODepartement> listeDepartements()
        {
            ObservableCollection<DAODepartement> l = DALDepartement.selectDepartement();
            return l;
        }
        public static DAODepartement getDepatrement(int idDepartement)
        {
            DAODepartement p = DALDepartement.getDepartement(idDepartement);
            return p;
        }

        public static void updateDepartement(DepartementViewModel d)
        {
            DALDepartement.updateDepartement(new DAODepartement(d.idDepartementProperty,d.nomDepartementProperty));
        }

        public static void supprimerDepartement(int id)
        {
            DALDepartement.supprimerDepartement(id);
        }

        public static void insertDepartement(DepartementViewModel d)
        {
            DALDepartement.insertDepartement(new DAODepartement(d.nomDepartementProperty));
        }
    }
}
