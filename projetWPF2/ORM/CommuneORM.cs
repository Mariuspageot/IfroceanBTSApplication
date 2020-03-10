using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class CommuneORM
    {
        public static CommuneViewModel getCommune(int idCommune)
        {
            DAOCommune cDAO = DAOCommune.getCommune(idCommune);
            int idDep = cDAO.idDepartementDAOCommune;
            DepartementViewModel d = DepartementORM.getDepartement(idDep);
            CommuneViewModel c = new CommuneViewModel(cDAO.idDAOCommune, cDAO.nomDAOCommune, d);
            return c;
        }

        public static ObservableCollection<CommuneViewModel> listeCommune()
        {
            ObservableCollection<DAOCommune> lDAO = DAOCommune.listeCommune();
            ObservableCollection<CommuneViewModel> l = new ObservableCollection<CommuneViewModel>();
            foreach (DAOCommune element in lDAO)
            {
                int idDep = element.idDepartementDAOCommune;

                DepartementViewModel d = DepartementORM.getDepartement(idDep); // Plus propre que d'aller chercher le métier dans la DAO.
                CommuneViewModel c = new CommuneViewModel(element.idDAOCommune, element.nomDAOCommune, d);
                l.Add(c);
            }
            return l;
        }
        public static void insertCommune(CommuneViewModel commune)
        {
            DAOCommune.insertCommune(commune);
        }
        public static void supprimerCommune(CommuneViewModel commune)
        {
            DAOCommune.deleteCommune(commune.idCommuneProperty);
        }
    }
}
