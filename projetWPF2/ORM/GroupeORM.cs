using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class GroupeORM
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idGroupe"></param>
        /// <returns></returns>
        public static GroupeViewModel getGroupe(int idGroupe)
        {
            DAOGroupe m = DAOGroupe.getGroupe(idGroupe);
            GroupeViewModel groupe = new GroupeViewModel(m.idGroupeDAO, m.nomGroupeDAO);
            return groupe;
        }
        public static void updateGroupe(GroupeViewModel p)
        {
            DAOGroupe.updateGroupe(p.IdGroupe, p.NomGroupe);
        }
        public static ObservableCollection<GroupeViewModel> listeGroupes()
        {
            ObservableCollection<DAOGroupe> lDAO = DAOGroupe.listeGroupes();
            ObservableCollection<GroupeViewModel> l = new ObservableCollection<GroupeViewModel>();
            foreach (var element in lDAO)
            {
                GroupeViewModel p = new GroupeViewModel(element.idGroupeDAO, element.nomGroupeDAO);
                l.Add(p);
            }

            return l;
        }

    }
}
