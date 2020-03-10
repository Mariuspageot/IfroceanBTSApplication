
using System;
using System.Collections.ObjectModel;

namespace projetWPF2
{
    public class DAOEtude
    {
        public int idDAOEtude;
        public string titreDAOEtude;
        public int idEnsemblePlagesDAOEtude;
        public DateTime dateDAOEtude;
        public int idEquipe;

        public DAOEtude(int id, string titre, int idEnsemblePlages, DateTime date, int equipe)
        {
            this.idDAOEtude = id;
            this.titreDAOEtude = titre;
            this.idEnsemblePlagesDAOEtude = idEnsemblePlages;
            this.dateDAOEtude = date;
            this.idEquipe = equipe;
        }
        public DAOEtude( string titre, int idEnsemblePlages, DateTime date, int equipe)
        {

            this.titreDAOEtude = titre;
            this.idEnsemblePlagesDAOEtude = idEnsemblePlages;
            this.dateDAOEtude = date;
            this.idEquipe = equipe;
        }
        public static ObservableCollection<DAOEtude> listeEtudes()
        {
            ObservableCollection<DAOEtude> l = DALEtude.selectEtudes();
            return l;
        }

        public static DAOEtude getEtude(int id)
        {
            DAOEtude p = DALEtude.getEtude(id);
            return p;
        }

        public static void updateEtude(EtudeViewModel p)
        {
            DALEtude.updateEtude(new DAOEtude(p.idEtudeProperty, p.titreEtudeProperty, p.listePlagesProperty.idEnsembleProperty, p.dateEtudeProperty, p.equipeEtudeProperty.idEquipeProperty));
        }

        public static void supprimerEtude(int id)
        {
            DALEtude.supprimerEtude(id);
        }

        public static void insertEtude(EtudeViewModel p)
        {
            DALEtude.insertEtude(new DAOEtude(p.titreEtudeProperty, p.listePlagesProperty.idEnsembleProperty, p.dateEtudeProperty, p.equipeEtudeProperty.idEquipeProperty));
        }
    }
}