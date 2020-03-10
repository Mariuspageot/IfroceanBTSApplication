using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class DepartementORM
    {
        public static DepartementViewModel getDepartement(int idDep)
        {
            DAODepartement m = DAODepartement.getDepatrement(idDep);
            DepartementViewModel departement = new DepartementViewModel(m.idDepartement, m.nomDAODepartement);
            return departement;
        }
        public static void updateDepartement(DepartementViewModel d)
        {
            DAODepartement.updateDepartement(d);
        }
        public static ObservableCollection<DepartementViewModel> listeDepartement()
        {
            ObservableCollection<DAODepartement> lDAO = DAODepartement.listeDepartements();
            ObservableCollection<DepartementViewModel> l = new ObservableCollection<DepartementViewModel>();
            foreach (var element in lDAO)
            {
                DepartementViewModel p = new DepartementViewModel(element.idDepartement, element.nomDAODepartement);
                l.Add(p);
            }

            return l;
        }
    }
}
