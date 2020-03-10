using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    public class DepartementViewModel : INotifyPropertyChanged
    {
        private int idDepartement;
        private string nomDepartement;
        private string concat;

        public DepartementViewModel(int id, string nom)
        {
            this.idDepartement = id;
            this.nomDepartement = nom;
        }
        public DepartementViewModel( string nom)
        {
            this.nomDepartement = nom;
        }
        public int idDepartementProperty
        {
            get { return idDepartement; }
        }

        public String nomDepartementProperty
        {
            get { return nomDepartement; }
            set
            {
                nomDepartement = value.ToUpper();
                this.concatProperty = value.ToUpper();
                OnPropertyChanged("nomDepartementProperty");
            }

        }
        public String concatProperty
        {
            get { return ""; }
            set
            {
                this.concat = "Ajouter " + value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                DAODepartement.updateDepartement(this);
            }
        }
    }
}
