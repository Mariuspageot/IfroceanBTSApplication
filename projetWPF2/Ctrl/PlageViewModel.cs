using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    public class PlageViewModel : INotifyPropertyChanged
    {
        private int idPlage;
        private string nomPlage;
        private int superficie;
        public CommuneViewModel Commune;

        public PlageViewModel(int id, string nom, CommuneViewModel Com, int sup)
        {
            this.idPlage = id;
            this.nomPlage = nom;
            this.Commune = Com;
            this.superficie = sup;
        }
        public PlageViewModel(string nom, CommuneViewModel Com, int sup)
        {
            this.nomPlage = nom;
            this.Commune = Com;
            this.superficie = sup;
        }
        public int idPlageProperty
        {
            get { return idPlage; }
        }

        public String nomPlageProperty
        {
            get { return nomPlage; }
            set
            {
                nomPlage = value.ToUpper();
                OnPropertyChanged("nomPlageProperty");
            }
        }
        public string nomCommuneProperty
        {
            get { return Commune.nomCommuneProperty; }
        }
        public string nomDepartementProperty
        {
            get { return Commune.departement.nomDepartementProperty; }
        }
        public int superficieProperty
        {
            get { return superficie; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                DAOPlage.updatePlage(this);
            }
        }
    }
}
