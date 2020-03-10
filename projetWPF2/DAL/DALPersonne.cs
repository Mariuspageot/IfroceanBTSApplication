using System.Collections.ObjectModel;
using System.ComponentModel;
using MySql.Data.MySqlClient;

namespace projetWPF2
{
    class DALPersonne
    {
        private static MySqlConnection connection;
        public DALPersonne()
        {
            DALConnection.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }

        public static ObservableCollection<DAOPersonne> selectPersonnes()
        {
            ObservableCollection<DAOPersonne> l = new ObservableCollection<DAOPersonne>();
            string query = "SELECT * FROM personne;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DAOPersonne p = new DAOPersonne(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4));
                l.Add(p);
            }
            reader.Close();
            return l;
        }

        public static void updatePersonne(DAOPersonne p)
        {
            string query = "UPDATE personne set nom=\"" + p.nomDAOPersonne + "\", prenom=\"" + p.prenomDAOPersonne + "\", idGroupe=\"" + p.groupeDAOPersonne + "\" where idPersonne=" + p.idDAOPersonne + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertPersonne(DAOPersonne p)
        {
            string query = "INSERT INTO personne (`nom`, `prenom`, `idGroupe`,`passwd`) VALUES (\"" + p.nomDAOPersonne + "\",\"" + p.prenomDAOPersonne + "\",\"" + p.groupeDAOPersonne + "\",\"" + p.passwdDAOPersonne + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }

        public static void supprimerPersonne(int id)
        {
            string query = "DELETE FROM personne WHERE idPersonne = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static DAOPersonne getPersonne(int idPersonne)
        {
            string query = "SELECT * FROM personne WHERE idPersonne=" + idPersonne + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            DAOPersonne pers = new DAOPersonne(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4));
            reader.Close();
            return pers;
        }
    }
}

