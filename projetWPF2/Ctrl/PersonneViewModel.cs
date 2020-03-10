using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace projetWPF2
{
    public class PersonneViewModel : INotifyPropertyChanged
    {
        private int idPersonne { get; set; }
        private string nomPersonne { get; set; }
        private string prenomPersonne { get; set; }
        private GroupeViewModel groupePersonne { get; set; }
        public List<EquipeViewModel> Equipes { get; set; }
        private string passwdPersonne { get; set; }

        public  PersonneViewModel(int id, string nom, string prenom, GroupeViewModel groupe, string passwd)
        {
            this.idPersonne = id;
            this.nomPersonneProperty = nom;
            this.prenomPersonneProperty = prenom;
            this.groupePersonne = groupe;
            passwdPersonne = passwd;
        }
        public  PersonneViewModel( string nom, string prenom, GroupeViewModel groupe, string passwd)
        {
            this.nomPersonneProperty = nom;
            this.prenomPersonneProperty = prenom;
            this.groupePersonne = groupe;
            passwdPersonne = passwd;
        }
        public int idPersonneProperty
        {
            get { return idPersonne; }
        }

        public String nomPersonneProperty
        {
            get { return nomPersonne; }
            set
            {
                nomPersonne = value.ToUpper();
                OnPropertyChanged("nomPersonneProperty");
            }

        }
        public String prenomPersonneProperty
        {
            get { return prenomPersonne; }
            set
            {
                this.prenomPersonne = value; 
                OnPropertyChanged("prenomPersonneProperty");
            }
        }


        public String GroupePersonne
        {
            get { return groupePersonne.NomGroupe; }
        }
        public int idGroupeProperty { get { return groupePersonne.IdGroupe; } }
        public string passwdPersonneProperty { get { return passwdPersonne; } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                DAOPersonne.updatePersonne(this);
            }
        }
    }
}