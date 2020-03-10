using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    public class DAOGroupe
    {
        public int idGroupeDAO;
        public string nomGroupeDAO;
        public DAOGroupe(int idGroupeDAO, string nomGroupeDAO)
        {
            this.idGroupeDAO = idGroupeDAO;
            this.nomGroupeDAO = nomGroupeDAO;
        }
        public static DAOGroupe getGroupe(int idGroupe)
        {
            DAOGroupe groupe = DALGroupe.getGroupe(idGroupe);
             return groupe;
        }
        public static void updateGroupe(int idGroupe, String nomGroupe)
        {
            DALGroupe.updateGroupe(new DAOGroupe( idGroupe, nomGroupe));
        }
        public static ObservableCollection<DAOGroupe> listeGroupes()
        {
            ObservableCollection<DAOGroupe> l = DALGroupe.selectGroupes();
            return l;
        }
    }
}
