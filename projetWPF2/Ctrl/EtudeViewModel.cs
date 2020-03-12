
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace projetWPF2
{
    public class EtudeViewModel : INotifyPropertyChanged
    {
        private int idEtude { get; set; }
        private string titreEtude { get; set; }
        private DateTime dateEtude { get; set; }

        public EtudeViewModel(int id, string titre, DateTime date)
        {
            idEtude = id;
            titreEtude = titre;
            dateEtude = date;
        }
        public EtudeViewModel(string titre, DateTime date)
        {
            titreEtude = titre;
            dateEtude = date;
        }
        public int idEtudeProperty { get { return idEtude; } }
        public string titreEtudeProperty { get { return titreEtude; } }
        public DateTime dateEtudeProperty { get { return dateEtude; } }

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