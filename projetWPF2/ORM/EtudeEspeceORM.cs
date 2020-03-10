using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class EtudeEspeceORM
    {
        public static EtudeEspeceViewModel GetEtudeEspece(int id)
        {
            DAOEtudeEspece etudeEspece = DAOEtudeEspece.getEtudeEspece(id);
            EtudeEspeceViewModel etudeEspeceView = new EtudeEspeceViewModel(etudeEspece.idDAOEtudeEspece, etudeEspece.nombreDAOEtudeEspece, etudeEspece.idEspeceDAOEtudeEspece, etudeEspece.idEtudeDAOEtudeEspece);
            return etudeEspeceView;
        }
        public static ObservableCollection<EtudeEspeceViewModel> listEtude()
        {
            ObservableCollection<EtudeEspeceViewModel> etudeEspeces = new ObservableCollection<EtudeEspeceViewModel>();
            ObservableCollection<DAOEtudeEspece> DAOee = DAOEtudeEspece.listeEtudeEspeces();
            foreach (DAOEtudeEspece etudeEspece in DAOee)
            {
                EtudeEspeceViewModel etudeEspece1 = new EtudeEspeceViewModel(etudeEspece.idDAOEtudeEspece, etudeEspece.nombreDAOEtudeEspece, etudeEspece.idEspeceDAOEtudeEspece, etudeEspece.idEtudeDAOEtudeEspece);
                etudeEspeces.Add(etudeEspece1);
            }
            return etudeEspeces;
        }
        public static void ajouter(EtudeEspeceViewModel etudeEspece) 
        {
            DAOEtudeEspece.insertEtudeEspece(etudeEspece);
        }
        public static void supprimer(EtudeEspeceViewModel etudeEspece)
        {
            DAOEtudeEspece.supprimerEtudeEspece(etudeEspece);
        }
    }
}
