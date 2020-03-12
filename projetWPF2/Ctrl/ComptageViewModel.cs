using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class ComptageViewModel
    {
        public int idComptage;
        public int nbDeParticipants;
        public EtudeViewModel etude;
        public PlageViewModel plage;
        public PersonneViewModel personne;
        public NbEspecesViewModel nbEspeces;
        public string coordonnees;

        public ComptageViewModel(int idComptage, int nbDeParticipants, EtudeViewModel etude, PlageViewModel plage, PersonneViewModel personne, NbEspecesViewModel nbEspeces, string coordonnees)
        {
            this.idComptage = idComptage;
            this.nbDeParticipants = nbDeParticipants;
            this.etude = etude;
            this.plage = plage;
            this.personne = personne;
            this.nbEspeces = nbEspeces;
            this.coordonnees = coordonnees;
        }
        public ComptageViewModel(int nbDeParticipants, EtudeViewModel etude, PlageViewModel plage, PersonneViewModel personne, NbEspecesViewModel nbEspeces, string coordonnees)
        {
            this.nbDeParticipants = nbDeParticipants;
            this.etude = etude;
            this.plage = plage;
            this.personne = personne;
            this.nbEspeces = nbEspeces;
            this.coordonnees = coordonnees;
        }
        public int idComptageProperty
        {
            get { return idComptage; }
        }
        public int nbDeParticipantsProperty
        {
            get { return nbDeParticipants; }
        }




    }
}