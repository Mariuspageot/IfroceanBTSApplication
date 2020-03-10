using System.ComponentModel;

namespace projetWPF2
{
    public class EtudeEspeceViewModel : INotifyPropertyChanged
    {
        private int idEtudeEspece { get; set; }
        private int nombre { get; set; }
        private int idEspece { get; set; }
        private int idEtude { get; set; }


        public EtudeEspeceViewModel(int id, int nb, int idEs, int idEt)
        {
            idEtudeEspece = id;
            nombre = nb;
            idEspece = idEs;
            idEtude = idEt;
        }
        public EtudeEspeceViewModel( int nb, int idEs, int idEt)
        {
            nombre = nb;
            idEspece = idEs;
            idEtude = idEt;
        }

        public int idEtudeEspeceProperty { get { return idEtudeEspece; } }
        public int nombreProperty { get { return nombre; } }
        public int idEspeceProperty { get { return idEspece; } }
        public int idEtudeProperty { get { return idEtude; } }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                DAOEtudeEspece.updateEtudeEspece(this);
            }
        }
    }
}