using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class DALDepartement
    {
        private static MySqlConnection connection;
        public DALDepartement()
        {
            DALConnection.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }

        public static ObservableCollection<DAODepartement> selectDepartement()
        {
            ObservableCollection<DAODepartement> l = new ObservableCollection<DAODepartement>();
            string query = "SELECT * FROM departement;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DAODepartement d = new DAODepartement(reader.GetInt32(0), reader.GetString(1));
                l.Add(d);
            }
            reader.Close();
            return l;
        }

        public static void updateDepartement(DAODepartement d)
        {
            string query = "UPDATE departement set nom=\"" + d.nomDAODepartement +"\" where idDepartement=" + d.idDepartement + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertDepartement(DAODepartement d)
        {
            string query = "INSERT INTO departement (`nom`) VALUES (\"" + d.nomDAODepartement +");";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerDepartement(int id)
        {
            string query = "DELETE FROM departement WHERE idDepartement = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static DAODepartement getDepartement(int idDepartement)
        {
            string query = "SELECT * FROM departement WHERE idDepartement=" + idDepartement + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            DAODepartement dep = new DAODepartement(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return dep;
        }
    }
}
