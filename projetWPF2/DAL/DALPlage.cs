using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class DALPlage
    {
        private static MySqlConnection connection;
        public DALPlage()
        {
            DALConnection.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }
        public static ObservableCollection<DAOPlage> selectPlage()
        {
            ObservableCollection<DAOPlage> l = new ObservableCollection<DAOPlage>();
            string query = "SELECT * FROM plage;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DAOPlage c = new DAOPlage(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));
                l.Add(c);
            }
            reader.Close();
            return l;
        }

        public static void updatePlage(DAOPlage c)
        {
            string query = "UPDATE plage set nom=\"" + c.nomDAOPlage + "\",idCommune=\"" + c.idCommuneDAOPlage + "\" where idPlage=" + c.idDAOPlage + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertPlage(DAOPlage c)
        {
            string query = "INSERT INTO plage (`Nom`,`idCommune`,`superficie`) VALUES (\"" + c.nomDAOPlage + "\",\"" + c.idCommuneDAOPlage+ "\",\"" + c.superficieDAOPlage + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerPlage(int id)
        {
            string query = "DELETE FROM plage WHERE idPlage = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static DAOPlage getPlage(int idDAOPlage)
        {
            string query = "SELECT * FROM plage WHERE idPlage=" + idDAOPlage + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            DAOPlage com = new DAOPlage(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));
            reader.Close();
            return com;
        }
    }
}
