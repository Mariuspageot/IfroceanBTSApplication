using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class NbEspecesViewModel
    {
        private int idNbEspece;
        public EspeceViewModel espece;
        private int nbEspeces;

        public NbEspecesViewModel(int idNbEspece, EspeceViewModel espece, int nbEspeces)
        {
            this.idNbEspece = idNbEspece;
            this.espece = espece;
            this.nbEspeces = nbEspeces;
        }
        public NbEspecesViewModel(EspeceViewModel espece, int nbEspeces)
        {
            this.espece = espece;
            this.nbEspeces = nbEspeces;
        }

        public int idNbEspeceProperty
        {
            get { return idNbEspece; }
        }
        public int nbEspecesProperty
        {
            get { return nbEspeces; }
        }
        public int idEspeceProperty
        {
            get { return espece.idEspeceProperty; }
        }
    }
}
