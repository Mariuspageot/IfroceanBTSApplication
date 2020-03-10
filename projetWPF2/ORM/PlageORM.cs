using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class PlageORM
    {
        public static PlageViewModel getPlage(int id)
        {
            DAOPlage pDAO = DAOPlage.getPlage(id);
            int idCom = pDAO.idCommuneDAOPlage;
            CommuneViewModel c = CommuneORM.getCommune(idCom);
            PlageViewModel p = new PlageViewModel(pDAO.idDAOPlage, pDAO.nomDAOPlage,c,pDAO.superficieDAOPlage);
            return p;
        }

        public static ObservableCollection<PlageViewModel> listePlage()
        {
            ObservableCollection<DAOPlage> lDAO = DAOPlage.listePlages();
            ObservableCollection<PlageViewModel> l = new ObservableCollection<PlageViewModel>();
            foreach (DAOPlage element in lDAO)
            {
                int idCom = element.idCommuneDAOPlage;

                CommuneViewModel c = CommuneORM.getCommune(idCom); // Plus propre que d'aller chercher le métier dans la DAO.
                PlageViewModel p = new PlageViewModel(element.idDAOPlage, element.nomDAOPlage, c,element.superficieDAOPlage);
                l.Add(p);
            }
            return l;
        }
        public static void ajouterPlage(PlageViewModel plage)
        {
            DAOPlage.insertPlage(plage);
        }
        public static void supprimerPlage(PlageViewModel plage)
        {
            DAOPlage.supprimerPlage(plage.idPlageProperty);
        }
    }
}
