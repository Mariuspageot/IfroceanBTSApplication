using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class DALNbEspece
    {
        private static MySqlConnection connection;
        public DALNbEspece()
        {
            DALConnection.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }

        public static ObservableCollection<DAONbEspece> listeNbEspece()
        {
            ObservableCollection<DAONbEspece> l = new ObservableCollection<DAONbEspece>();
            string query = "SELECT * FROM nbespece;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DAONbEspece p = new DAONbEspece(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));
                l.Add(p);
            }
            reader.Close();
            return l;
        }

        public static void updateNbEspece(DAONbEspece p)
        {
            string query = "UPDATE nbespece set nombre=\"" + p.nbEspece + "\", idEspece=\"" + p.idEspece + "\" where idNbEspece=" + p.idNbEspece+ ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertNbEspece(DAONbEspece p)
        {
            string query = "INSERT INTO nbespece (`nombre`, `idEspece`) VALUES (\"" + p.nombreDAOEtudeEspece + "\",\"" + p.idEspeceDAOEtudeEspece + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }

        public static void deletedNbEspece(int id)
        {
            string query = "DELETE FROM nbespece WHERE idNbEspece = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
    }
}
