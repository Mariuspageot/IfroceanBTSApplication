using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace projetWPF2
{
    public class DAOEnsembles
    {
        public int idDAOEnsemblePlage;
        public string nomDAOEnsemblePlage;

        public DAOEnsembles(int id, string nom)
        {
            idDAOEnsemblePlage = id;
            nomDAOEnsemblePlage = nom;
        }
        public DAOEnsembles(string nom)
        {
            nomDAOEnsemblePlage = nom;
        }
        public static ObservableCollection<DAOEnsembles> listeEnsembles()
        {
            ObservableCollection<DAOEnsembles> l = DALEnsembles.selectEnsembles();
            return l;
        }
        public static DAOEnsembles getEnsembles(int id)
        {
            DAOEnsembles p = DALEnsembles.getEnsembles(id);
            return p;
        }

        public static void updateEnsembles(EnsemblesViewModel p)
        {
            DALEnsembles.updateEnsembles(new DAOEnsembles(p.idEnsembleProperty, p.nomEnsembleProperty));
        }

        public static void supprimerEnsembles(int id)
        {
            DALEnsembles.supprimerEnsembles(id);
        }

        public static void insertEnsembles(EnsemblesViewModel p)
        {
            DALEnsembles.insertEnsembles(new DAOEnsembles(p.nomEnsembleProperty));
        }
    }
}