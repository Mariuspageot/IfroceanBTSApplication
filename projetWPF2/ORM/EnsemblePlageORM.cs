using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class EnsemblePlageORM
    {
        public static EnsemblesViewModel GetEnsembles(int id)
        {
            DAOEnsembles DAO = DAOEnsembles.getEnsembles(id);
            EnsemblesViewModel ensembles = new EnsemblesViewModel(DAO.idDAOEnsemblePlage, DAO.nomDAOEnsemblePlage);
            return ensembles;
        }

        public static ObservableCollection<EnsemblesViewModel> listeEnsembles()
        {
            ObservableCollection<DAOEnsembles> lDAO = DAOEnsembles.listeEnsembles();
            ObservableCollection<EnsemblesViewModel> l = new ObservableCollection<EnsemblesViewModel>();
            foreach (DAOEnsembles element in lDAO)
            {
                EnsemblesViewModel p = new EnsemblesViewModel(element.idDAOEnsemblePlage, element.nomDAOEnsemblePlage);
                l.Add(p);
            }
            return l;
        }
        public static void delete(EnsemblesViewModel ensembles)
        {
            DAOPlageEnsemble.supprimerEnsemble(ensembles);
            DAOEnsembles.supprimerEnsembles(ensembles.idEnsembleProperty);
        }
        public static void ajouterPlage(EnsemblesViewModel ensembles, PlageViewModel plage)
        {
            DAOPlageEnsemble.insertPlageEnsemble(ensembles, plage);
        }
        public static void deletePlage(EnsemblesViewModel ensembles, PlageViewModel plage)
        {
            DAOPlageEnsemble.supprimerPlageEnsemble(ensembles, plage);
        }
        public static void insertEnsemble(EnsemblesViewModel ensembles)
        {
            DAOEnsembles.insertEnsembles(ensembles);
        }

    }
}
