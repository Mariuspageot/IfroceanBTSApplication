using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class DALEtude
    {
        private static MySqlConnection connection;
        public DALEtude()
        {
            DALConnection.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }

        public static ObservableCollection<DAOEtude> selectEtudes()
        {
            ObservableCollection<DAOEtude> l = new ObservableCollection<DAOEtude>();
            string query = "SELECT * FROM etude;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DAOEtude p = new DAOEtude(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetInt32(4));
                l.Add(p);
            }
            reader.Close();
            return l;
        }

        public static void updateEtude(DAOEtude p)
        {
            string query = "UPDATE etude set titre=\"" + p.titreDAOEtude + "\", idEnsemblePlage=\"" + p.idEnsemblePlagesDAOEtude + "\", date=\"" + p.dateDAOEtude + "\", idEquipe=\"" +p.idEquipe +"\" where idEtude=" + p.idDAOEtude + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertEtude(DAOEtude p)
        {
            string query = "INSERT INTO etude (`titre`, `idEnsemblePlage`, `date`,`idEquipe`) VALUES (\"" + p.titreDAOEtude + "\",\"" + p.idEnsemblePlagesDAOEtude + "\",\"" + p.dateDAOEtude + "\",\"" + p.idEquipe + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }

        public static void supprimerEtude(int id)
        {
            string query = "DELETE FROM etude WHERE idEtude = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static DAOEtude getEtude(int id)
        {
            string query = "SELECT * FROM etude WHERE idEtude=" + id + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            DAOEtude pers = new DAOEtude(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetInt32(4));
            reader.Close();
            return pers;
        }
    }
}
