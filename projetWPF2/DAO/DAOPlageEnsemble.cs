using System.Collections.ObjectModel;

namespace projetWPF2
{
    class DAOPlageEnsemble
    {
        public int plageDAO_idPlage;
        public int ensembleplageDAO_idEnsemblePlage;

        public DAOPlageEnsemble(int idPlage, int idEnsemblePlage)
        {
            this.plageDAO_idPlage = idPlage;
            this.ensembleplageDAO_idEnsemblePlage = idEnsemblePlage;
        }
        public static ObservableCollection<DAOPlageEnsemble> listePlageEnsembles()
        {
            ObservableCollection<DAOPlageEnsemble> l = DALPlageEnsemble.selectPlagesEnsembles();
            return l;
        }

        public static DAOPlageEnsemble getPlageEnsemble(int id)
        {
            DAOPlageEnsemble p = DALPlageEnsemble.getPlagesEnsembles(id);
            return p;
        }


        public static void updatePlageEnsemble(EnsemblesViewModel p, PlageViewModel pl)
        {
            DALPlageEnsemble.updatePlagesEnsembles(p,pl);
        }
        public static void supprimerEnsemble(EnsemblesViewModel p)
        {
            DALPlageEnsemble.supprimerEnsembles(p);
        }

        public static void supprimerPlageEnsemble(EnsemblesViewModel p, PlageViewModel pl)
        {
            DALPlageEnsemble.supprimerPlagesEnsembles(p,pl);
        }

        public static void insertPlageEnsemble(EnsemblesViewModel p, PlageViewModel pl)
        {
            DALPlageEnsemble.insertPlagesEnsembles(p,pl);
        }
    }
}