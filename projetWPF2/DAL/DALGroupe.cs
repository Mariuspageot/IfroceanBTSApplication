using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    public class DALGroupe
    {
        private static MySqlConnection connection;

        public DALGroupe()
        {
            DALConnection.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }


        public static DAOGroupe getGroupe(int idGroupe)
        {
            string query = "SELECT * FROM Groupe WHERE idGroupe=" + idGroupe + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            DAOGroupe met = new DAOGroupe(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return met;
        }

        public static void updateGroupe(DAOGroupe g)
        {
            string query = "UPDATE Groupe set nomGroupe=\"" + g.nomGroupeDAO + "\" where idGroupe=" + g.idGroupeDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static ObservableCollection<DAOGroupe> selectGroupes()
        {
            ObservableCollection<DAOGroupe> l = new ObservableCollection<DAOGroupe>();
            string query = "SELECT * FROM groupe;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DAOGroupe g = new DAOGroupe(reader.GetInt32(0), reader.GetString(1));
                l.Add(g);
            }
            reader.Close();
            return l;
        }

    }
}
