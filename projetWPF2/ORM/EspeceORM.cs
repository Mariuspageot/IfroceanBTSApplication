using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class EspeceORM
    {
        public static EspeceViewModel getEspece(int id)
        {
            DAOEspece pDAO = DAOEspece.getEspece(id);
            EspeceViewModel p = new EspeceViewModel(pDAO.idDAOEspece, pDAO.nomDAOEspece);

            return p;
        }
        public static ObservableCollection<EspeceViewModel> listeEspeces()
        {
            ObservableCollection<DAOEspece> lDAO = DAOEspece.listeEspeces();
            ObservableCollection<EspeceViewModel> l = new ObservableCollection<EspeceViewModel>();
            foreach (DAOEspece element in lDAO)
            {
                EspeceViewModel p = new EspeceViewModel(element.idDAOEspece, element.nomDAOEspece);
                l.Add(p);
            }
            return l;
        }
        public static void ajouterEspece(EspeceViewModel espece)
        {
            DAOEspece.insertEspece(espece);
        }
        public static void deleteEspece(EspeceViewModel espece)
        {
            DAOEspece.supprimerEspece(espece);
        }
    }
}
