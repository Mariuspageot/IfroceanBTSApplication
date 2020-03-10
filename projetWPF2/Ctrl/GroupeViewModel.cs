using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    public class GroupeViewModel : INotifyPropertyChanged
    {
        private int idGroupe ;
        private string nomGroupe ;
        public GroupeViewModel(int idGroupe, string nomGroupe)
        {
            this.idGroupe = idGroupe;
            this.nomGroupe = nomGroupe;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                GroupeORM.updateGroupe(this);
            }
        }
        public String NomGroupe
        {
            get { return nomGroupe; }
        }
        public int IdGroupe { get { return idGroupe; } }
    }
}
