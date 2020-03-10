using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class DALEnsembles
    {
        private static MySqlConnection connection;
        public DALEnsembles()
        {
            DALConnection.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }

        public static ObservableCollection<DAOEnsembles> selectEnsembles()
        {
            ObservableCollection<DAOEnsembles> l = new ObservableCollection<DAOEnsembles>();
            string query = "SELECT * FROM ensembleplage;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DAOEnsembles p = new DAOEnsembles(reader.GetInt32(0), reader.GetString(1));
                l.Add(p);
            }
            reader.Close();
            return l;
        }

        public static void updateEnsembles(DAOEnsembles p)
        {
            string query = "UPDATE ensembleplage set nom=\"" + p.nomDAOEnsemblePlage + "\" where idEnsemblePlage=" + p.idDAOEnsemblePlage + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertEnsembles(DAOEnsembles p)
        {
            string query = "INSERT INTO ensembleplage (`nom`) VALUES (\"" + p.nomDAOEnsemblePlage +  "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }

        public static void supprimerEnsembles(int id)
        {
            string query = "DELETE FROM ensembleplage WHERE idEnsemblePlage = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static DAOEnsembles getEnsembles(int id)
        {
            string query = "SELECT * FROM ensembleplage WHERE idEnsemblePlage=" + id + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            DAOEnsembles pers = new DAOEnsembles(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return pers;
        }
    }
}
    