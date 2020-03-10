using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class DALPlageEnsemble
    {
        private static MySqlConnection connection;
        public DALPlageEnsemble()
        {
            DALConnection.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }

        public static ObservableCollection<DAOPlageEnsemble> selectPlagesEnsembles()
        {
            ObservableCollection<DAOPlageEnsemble> l = new ObservableCollection<DAOPlageEnsemble>();
            string query = "SELECT * FROM plage_has_ensembleplage;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DAOPlageEnsemble p = new DAOPlageEnsemble(reader.GetInt32(0), reader.GetInt32(1));
                l.Add(p);
            }
            reader.Close();
            return l;
        }

        public static void updatePlagesEnsembles(EnsemblesViewModel p, PlageViewModel pl)
        {
            string query = "UPDATE plage_has_ensembleplage set plage_idPlage=\"" + p.idEnsembleProperty + "\" where ensembleplage_idEnsemblePlage=" + pl.idPlageProperty + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertPlagesEnsembles(EnsemblesViewModel p, PlageViewModel pl)
        {
            string query = "INSERT INTO plage_has_ensembleplage ( `ensembleplage_idEnsemblePlage`,`plage_idPlage`) VALUES (\"" + p.idEnsembleProperty + "\",\"" + pl.idPlageProperty + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerEnsembles(EnsemblesViewModel p)
        {
            string query = "DELETE FROM plage_has_ensembleplage WHERE ensembleplage_idEnsemblePlage = \"" + p.idEnsembleProperty + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static void supprimerPlagesEnsembles(EnsemblesViewModel p, PlageViewModel pl)
        {
            string query = "DELETE FROM plage_has_ensembleplage WHERE ensembleplage_idEnsemblePlage = \"" + p.idEnsembleProperty + "\" AND plage_idPlage =\"" + pl.idPlageProperty + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static DAOPlageEnsemble getPlagesEnsembles(int id)
        {
            string query = "SELECT * FROM plage_has_ensembleplage WHERE ensembleplage_idEnsemblePlage=" + id + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            DAOPlageEnsemble pers = new DAOPlageEnsemble(reader.GetInt32(0), reader.GetInt32(1));
            reader.Close();
            return pers;
        }
    }
}
