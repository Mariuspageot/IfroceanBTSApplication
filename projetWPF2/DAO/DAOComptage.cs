using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class DAOComptage
    {
        public int idComptage;
        public int nbDeParticipants;
        public string coordonnees;
        public int idEtude;
        public int idNbEspeces;
        public int idPlage;
        public int idPersonne;

        public DAOComptage(int idComptage, int nbDeParticipants, string coordonnees, int idEtude, int idNbEspeces, int idPlage, int idPersonne)
        {
        this.idComptage=idComptage;
        this.nbDeParticipants=nbDeParticipants;
        this.coordonnees=coordonnees;
        this.idEtude=idEtude;
        this.idNbEspeces = idNbEspeces;
        this.idPlage=idPlage;
        this.idPersonne=idPersonne;
        }
        public DAOComptage( int nbDeParticipants, string coordonnees, int idEtude, int idNbEspeces, int idPlage, int idPersonne)
        {
            this.nbDeParticipants = nbDeParticipants;
            this.coordonnees = coordonnees;
            this.idEtude = idEtude;
            this.idNbEspeces = idNbEspeces;
            this.idPlage = idPlage;
            this.idPersonne = idPersonne;
        }
        public ObservableCollection<DAOComptage> listeComptage()
        {
            ObservableCollection<DAOComptage> liste = DALComptage.selectComptages();
            return liste;
        }
        public void insertComptage(ComptageViewModel comptage)
        {
            DALComptage.insertComptage(new DAOComptage(comptage.nbDeParticipants, comptage.coordonnees, comptage.etude.idEtudeProperty, comptage.nbEspeces.idNbEspeceProperty, comptage.plage.idPlageProperty, comptage.personne.idPersonneProperty));
        }
        public void updateComptage(ComptageViewModel comptage)
        {
            DALComptage.updateComptage(new DAOComptage(comptage.idComptage, comptage.nbDeParticipants, comptage.coordonnees, comptage.etude.idEtudeProperty, comptage.nbEspeces.idNbEspeceProperty, comptage.plage.idPlageProperty, comptage.personne.idPersonneProperty));
        }
        public void deletedComptage(ComptageViewModel comptage)
        {
            DALComptage.deletedComptage(comptage.idComptageProperty);
        }

    }
}
