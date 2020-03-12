using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{

    class DALPlageEtude
    {
        private static MySqlConnection connection;
        public DALPlageEtude()
        {
            DALConnection.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }
        public static ObservableCollection<DAOPlageEtude> listePlageEtude()
        {
            ObservableCollection<DAOPlageEtude> l = new ObservableCollection<DAOPlageEtude>();
            string query = "SELECT * FROM plage_has_etude;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DAOPlageEtude c = new DAOPlageEtude(reader.GetInt32(0), reader.GetInt32(1));
                l.Add(c);
            }
            reader.Close();
            return l;
        }
        public static void updatePlageEtude(DAOPlageEtude plageEtude)
        {
            string query = "UPDATE plage_has_etude set plage_idPlage=\"" + plageEtude.idPlage + "\" where etude_idEtude=" + plageEtude.idEtude + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertPlageEtude(DAOPlageEtude plageEtude)
        {
            string query = "INSERT INTO plage_has_etude ( `plage_idPlage`,`etude_idEtude`) VALUES (\"" + plageEtude.idPlage + "\",\"" + plageEtude.idEtude + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void deletedEtude(int idEtude)
        {
            string query = "DELETE FROM plage_has_etude WHERE etude_idEtude = \"" + idEtude + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static void deletedPlageEtude(DAOPlageEtude plageEtude)
        {
            string query = "DELETE FROM plage_has_etude WHERE etude_idEtude = \"" + plageEtude.idEtude + "\" AND plage_idPlage =\"" + plageEtude.idPlage + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
    }
    
}
