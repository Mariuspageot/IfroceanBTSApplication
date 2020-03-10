using System.ComponentModel;

namespace projetWPF2
{
    public class EspeceViewModel : INotifyPropertyChanged
    {
        private int idEspece { get; set; }
        private string nomEspece { get; set; }

        public EspeceViewModel(int id, string nom)
        {
            idEspece = id;
            nomEspece = nom;
        }
        public EspeceViewModel(string nom)
        {
            nomEspece = nom;
        }

        public int idEspeceProperty { get { return idEspece; } }
        public string nomEspeceProperty { get { return nomEspece; } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                DAOEspece.updateEspece(this);
            }
        }
    }
}