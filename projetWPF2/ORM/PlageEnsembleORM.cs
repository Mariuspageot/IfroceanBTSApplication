using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class PlageEnsembleORM
    {
        public static void ajouterPlage(EnsemblesViewModel ensembles, PlageViewModel plage)
        {
            DAOPlageEnsemble.insertPlageEnsemble(ensembles, plage);
        }
        public static void supprimerPlage(EnsemblesViewModel ensembles, PlageViewModel plage)
        {
            DAOPlageEnsemble.supprimerPlageEnsemble(ensembles, plage);
        }
        public static List<PlageViewModel> getplages(EnsemblesViewModel ensembles)
        {
            List<PlageViewModel> lp =
            DAOPlageEnsemble.listePlageEnsembles()
            .Where(e => e.ensembleplageDAO_idEnsemblePlage == ensembles.idEnsembleProperty)
            .Select(e => PlageORM.getPlage(e.plageDAO_idPlage)).ToList();
            return lp;
        }
    }
}
