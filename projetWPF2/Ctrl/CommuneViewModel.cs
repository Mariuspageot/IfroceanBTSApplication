using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    public class CommuneViewModel : INotifyPropertyChanged
    {
        private int idCommune;
        private string nomCommune;
        public DepartementViewModel departement;


        public CommuneViewModel(int id, string nom, DepartementViewModel dep)
        {
            this.idCommune = id;
            this.nomCommune = nom;
            this.departement = dep;
        }
        public CommuneViewModel(string nom, DepartementViewModel dep)
        {
            this.nomCommune = nom;
            this.departement = dep;
        }
        public int idCommuneProperty
        {
            get { return idCommune; }
        }
        public string nomDepartementProperty
        {
            get { return departement.nomDepartementProperty; }
        }

        public String nomCommuneProperty
        {
            get { return nomCommune; }
            set
            {
                nomCommune = value.ToUpper();
                OnPropertyChanged("nomCommuneProperty");
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                DAOCommune.updateCommune(this);
            }
        }
    }
}
