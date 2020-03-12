using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class DAONbEspece
    {
        public int idNbEspece;
        public int nbEspece;
        public int idEspece;

        public DAONbEspece(int idNbEspece, int nbEspece, int idEspece)
        {
            this.idNbEspece = idNbEspece;
            this.nbEspece = nbEspece;
            this.idEspece = idEspece;
        }
        public DAONbEspece(int nbEspece, int idEspece)
        {
            this.nbEspece = nbEspece;
            this.idEspece = idEspece;
        }
        public ObservableCollection<DAONbEspece> listeNbEspece()
        {
            ObservableCollection<DAONbEspece> liste = DALNbEspece.listeNbEspece();
            return liste;
        }
        public void updateNbEspece(NbEspecesViewModel espece)
        {
            DALNbEspece.updateNbEspece(new DAONbEspece(espece.idNbEspeceProperty,espece.nbEspecesProperty,espece.idEspeceProperty));
        }
        public void insertNbEspece(NbEspecesViewModel espece)
        {
            DALNbEspece.insertNbEspece(new DAONbEspece(espece.nbEspecesProperty,espece.idEspeceProperty));
        }
        public void deletedNbEspece(NbEspecesViewModel espece)
        {
            DALNbEspece.deletedNbEspece(espece.idNbEspeceProperty);
        }
    }
}
