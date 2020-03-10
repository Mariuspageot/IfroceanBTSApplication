
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace projetWPF2
{
    public class EtudeViewModel : INotifyPropertyChanged
    {
        private int idEtude { get; set; }
        private string titreEtude { get; set; }
        private EnsemblesViewModel listePlages { get; set; }
        private DateTime dateEtude { get; set; }
        private EquipeViewModel equipeEtude { get; set; }

        public EtudeViewModel(int id, string titre, EnsemblesViewModel plages, DateTime date, EquipeViewModel equipe)
        {
            idEtude = id;
            titreEtude = titre;
            listePlages = plages;
            dateEtude = date;
            equipeEtude = equipe;
        }
        public EtudeViewModel(string titre, EnsemblesViewModel plages, DateTime date, EquipeViewModel equipe)
        {
            titreEtude = titre;
            listePlages = plages;
            dateEtude = date;
            equipeEtude = equipe;
        }
        public int idEtudeProperty { get { return idEtude; } }
        public string titreEtudeProperty { get { return titreEtude; } }
        public EnsemblesViewModel listePlagesProperty { get { return listePlages; } }

        public string nomEnsembleProperty { get { return listePlagesProperty.nomEnsembleProperty; } }
        public DateTime dateEtudeProperty { get { return dateEtude; } }
        public EquipeViewModel equipeEtudeProperty { get { return equipeEtude; } }
        public string nomEquipeProperty { get { return equipeEtude.nomEquipeProperty; } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                DAOEtude.updateEtude(this);
            }
        }
    }
}