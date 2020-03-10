using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class EtudeORM
    {
        public static EtudeViewModel getEtude(int id)
        {
            DAOEtude pDAO = DAOEtude.getEtude(id);
            DAOEnsembles eDAO = DAOEnsembles.getEnsembles(pDAO.idEnsemblePlagesDAOEtude);
            EnsemblesViewModel e = new EnsemblesViewModel(eDAO.idDAOEnsemblePlage, eDAO.nomDAOEnsemblePlage);
            DAOEquipe eqDAO = DAOEquipe.getEquipe(pDAO.idEquipe);
            EquipeViewModel eq = new EquipeViewModel(eqDAO.idDAOEquipe, eqDAO.nomDAOEquipe);
            EtudeViewModel p = new EtudeViewModel(pDAO.idDAOEtude, pDAO.titreDAOEtude,e,pDAO.dateDAOEtude,eq);

            return p;
        }
        public static ObservableCollection<EtudeViewModel> listeEtudes()
        {
            ObservableCollection<DAOEtude> lDAO = DAOEtude.listeEtudes();

            ObservableCollection<EtudeViewModel> l = new ObservableCollection<EtudeViewModel>();
            foreach (DAOEtude element in lDAO)
            {
                DAOEnsembles eDAO = DAOEnsembles.getEnsembles(element.idEnsemblePlagesDAOEtude);
                DAOEquipe eqDAO = DAOEquipe.getEquipe(element.idEquipe);
                EquipeViewModel eq = new EquipeViewModel(eqDAO.idDAOEquipe,eqDAO.nomDAOEquipe);
                EnsemblesViewModel e = new EnsemblesViewModel(eDAO.idDAOEnsemblePlage,eDAO.nomDAOEnsemblePlage);
                EtudeViewModel p = new EtudeViewModel(element.idDAOEtude, element.titreDAOEtude,e,element.dateDAOEtude,eq);
                l.Add(p);
            }
            return l;
        }
        public static void insertEtude(string titre, EnsemblesViewModel ensembles, EquipeViewModel equipe)
        {
            DAOEtude.insertEtude(new EtudeViewModel(titre, ensembles, DateTime.Now, equipe));
        }
        public static void supprimerEtude(int id)
        {
            DAOEtude.supprimerEtude(id);
        }
    }
}
