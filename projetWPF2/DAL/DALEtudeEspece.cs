using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class DALEtudeEspece
    {
        private static MySqlConnection connection;
        public DALEtudeEspece()
        {
            DALConnection.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }

        public static ObservableCollection<DAOEtudeEspece> selectEtudeEspece()
        {
            ObservableCollection<DAOEtudeEspece> l = new ObservableCollection<DAOEtudeEspece>();
            string query = "SELECT * FROM etude/espece;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DAOEtudeEspece p = new DAOEtudeEspece(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));
                l.Add(p);
            }
            reader.Close();
            return l;
        }

        public static void updateEtudeEspece(DAOEtudeEspece p)
        {
            string query = "UPDATE etude/espece set nombre=\"" + p.nombreDAOEtudeEspece + "\", idEspece=\"" + p.idEspeceDAOEtudeEspece + "\", idEtude=\"" + p.idEtudeDAOEtudeEspece + "\" where idEtude/Espece=" + p.idDAOEtudeEspece+ ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertEtudeEspece(DAOEtudeEspece p)
        {
            string query = "INSERT INTO etude/espece (`nombre`, `idEspece`, `idEtude`) VALUES (\"" + p.nombreDAOEtudeEspece + "\",\"" + p.idEspeceDAOEtudeEspece + "\",\"" + p.idEtudeDAOEtudeEspece + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }

        public static void supprimerEtudeEspece(int id)
        {
            string query = "DELETE FROM etude/espece WHERE idEtude/Espece = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static DAOEtudeEspece getEtudeEspece(int id)
        {
            string query = "SELECT * FROM etude/espece WHERE idEtude/Espece=" + id + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            DAOEtudeEspece pers = new DAOEtudeEspece(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));
            reader.Close();
            return pers;
        }
    }
}
