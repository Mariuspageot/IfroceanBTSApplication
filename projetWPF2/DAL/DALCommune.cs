using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class DALCommune
    {
        private static MySqlConnection connection;
        public DALCommune()
        {
            DALConnection.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }
        public static ObservableCollection<DAOCommune> selectCommune()
        {
            ObservableCollection<DAOCommune> l = new ObservableCollection<DAOCommune>();
            string query = "SELECT * FROM Commune;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DAOCommune c = new DAOCommune(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                l.Add(c);
            }
            reader.Close();
            return l;
        }

        public static void updateCommune(DAOCommune c)
        {
            string query = "UPDATE commune set nom=\"" + c.nomDAOCommune + "\",idCommune=\"" + c.idDepartementDAOCommune + "\" where idCommune=" + c.idDAOCommune + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertCommune(DAOCommune c)
        {
            string query = "INSERT INTO Commune (`nom`,`idDepartement`) VALUES (\"" + c.nomDAOCommune + "\",\""+ c.idDAOCommune+ "\"); ";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerCommune(int id)
        {
            string query = "DELETE FROM commune WHERE idCommune = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static DAOCommune getCommune(int idDAOCommune)
        {
            string query = "SELECT * FROM commune WHERE idCommune=" + idDAOCommune + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            DAOCommune com = new DAOCommune(reader.GetInt32(0), reader.GetString(1),reader.GetInt32(2));
            reader.Close();
            return com;
        }
    }
}
