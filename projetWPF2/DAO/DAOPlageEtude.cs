using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class DAOPlageEtude
    {
        public int idPlage;
        public int idEtude;

        public DAOPlageEtude(int idPlage, int idEtude)
        {
            this.idEtude = idEtude;
            this.idPlage = idPlage;
        }
        public ObservableCollection<DAOPlageEtude> listePlageEtude()
        {
            ObservableCollection<DAOPlageEtude> liste = DALPlageEtude.listePlageEtude();
            return liste;
        }
        public void updatePlageEtude(PlageViewModel plage, EtudeViewModel etude)
        {
            DALPlageEtude.updatePlageEtude(new DAOPlageEtude(plage.idPlageProperty, etude.idEtudeProperty));
        }
        public void insertPlageEtude(PlageViewModel plage, EtudeViewModel etude)
        {
            DALPlageEtude.insertPlageEtude(new DAOPlageEtude( plage.idPlageProperty, etude.idEtudeProperty));
        }
        public void deletedEtude(EtudeViewModel etude)
        {
            DALPlageEtude.deletedEtude(etude.idEtudeProperty);
        }
        public void deletedPlageEtude(PlageViewModel plage, EtudeViewModel etude)
        {
            DALPlageEtude.deletedPlageEtude(new DAOPlageEtude(plage.idPlageProperty, etude.idEtudeProperty));
        }
    }
}
