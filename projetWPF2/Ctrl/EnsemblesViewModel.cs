using System.Collections.Generic;
using System.ComponentModel;

namespace projetWPF2
{
    public class EnsemblesViewModel : INotifyPropertyChanged
    {
        private int idEnsemble { get; set; }
        private string nomEnsemble { get; set; }
        private List<PlageViewModel> Plages { get; set; }

        public EnsemblesViewModel(int id, string nom, List<PlageViewModel> plages)
        {
            idEnsemble = id;
            nomEnsemble = nom;
            this.Plages = plages;
        }
        public EnsemblesViewModel(int id, string nom)
        {
            idEnsemble = id;
            nomEnsemble = nom;
        }
        public EnsemblesViewModel(string nom)
        {

            nomEnsemble = nom;
        }

        public EnsemblesViewModel( string nom, List<PlageViewModel> plages)
        {
            nomEnsemble = nom;
            this.Plages = plages;
        }
        public int idEnsembleProperty 
        {
            get { return idEnsemble; } 
        }
        public string nomEnsembleProperty 
        {
            get { return nomEnsemble; } 
        }
        public List<PlageViewModel> listPlageProrerty 
        {
            get { return Plages; } 
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                DAOEnsembles.updateEnsembles(this);
            }
        }
    }
}