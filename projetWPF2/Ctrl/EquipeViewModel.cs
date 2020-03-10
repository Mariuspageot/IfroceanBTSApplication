using System.Collections.Generic;
using System.ComponentModel;

namespace projetWPF2
{
    public class EquipeViewModel : INotifyPropertyChanged
    {
        private int idEquipe { get; set; }
        private string nomEquipe { get; set; }
        private List<PersonneViewModel> membreEquipe { get; set; }

        public  EquipeViewModel(int id, string nom, List<PersonneViewModel> membre)
        {
            idEquipe = id;
            nomEquipe = nom;
            membreEquipe = membre;
        }
        public EquipeViewModel(int id,string nom)
        {
            idEquipe = id;
            nomEquipe = nom;
        }
        public EquipeViewModel( string nom)
        {
            nomEquipe = nom;
        }
        public EquipeViewModel( string nom, List<PersonneViewModel> membre)
        {
            nomEquipe = nom;
            membreEquipe = membre;
        }
        public int idEquipeProperty { get { return idEquipe; } }
        public string nomEquipeProperty { get { return nomEquipe; } }

        public List<PersonneViewModel> membreEquipeProrerty { get { return membreEquipe; } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                DAOEquipe.updateEquipe(this);
            }
        }

    }
}