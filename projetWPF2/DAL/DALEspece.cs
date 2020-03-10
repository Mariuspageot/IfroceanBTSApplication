using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class DALEspece
    {
        private static MySqlConnection connection;

        public DALEspece()
        {
            DALConnection.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }


        public static DAOEspece getEspece(int id)
        {
            string query = "SELECT * FROM Espece WHERE idEspece=" + id + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            DAOEspece met = new DAOEspece(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return met;
        }

        public static void updateEspece(DAOEspece e)
        {
            string query = "UPDATE Groupe set nomEspece=\"" + e.nomDAOEspece + "\" where idEspece=" + e.idDAOEspece + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertEspece(DAOEspece e)
        {
            string query = "INSERT INTO espece (`nom`) VALUES (\"" + e.nomDAOEspece + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }

        public static void supprimerEspece(int id)
        {
            string query = "DELETE FROM espece WHERE idespece = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static ObservableCollection<DAOEspece> selectEspece()
        {
            ObservableCollection<DAOEspece> l = new ObservableCollection<DAOEspece>();
            string query = "SELECT * FROM espece;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DAOEspece e = new DAOEspece(reader.GetInt32(0), reader.GetString(1));
                l.Add(e);
            }
            reader.Close();
            return l;
        }
    }
}
