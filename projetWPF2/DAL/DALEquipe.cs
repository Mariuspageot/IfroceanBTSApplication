using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class DALEquipe
    {
        private static MySqlConnection connection;
        public DALEquipe()
        {
            DALConnection.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }

        public static ObservableCollection<DAOEquipe> selectEquipe()
        {
            ObservableCollection<DAOEquipe> l = new ObservableCollection<DAOEquipe>();
            string query = "SELECT * FROM equipe;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DAOEquipe e = new DAOEquipe(reader.GetInt32(0), reader.GetString(1));
                l.Add(e);
            }
            reader.Close();
            return l;
        }

        public static void updateEquipe(DAOEquipe e)
        {
            string query = "UPDATE equipe set nom=\"" + e.nomDAOEquipe + "\" where idEquipe=" + e.idDAOEquipe + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertEquipe(DAOEquipe p)
        {
            string query = "INSERT INTO equipe (`nom`) VALUES (\"" + p.nomDAOEquipe + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }

        public static void supprimerEquipe(DAOEquipe e)
        {
            string query = "DELETE FROM equipe WHERE idEquipe = \"" + e.idDAOEquipe + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static DAOEquipe getEquipe(int id)
        {
            string query = "SELECT * FROM equipe WHERE idEquipe=" + id + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            DAOEquipe e = new DAOEquipe(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return e;
        }
    }
}
