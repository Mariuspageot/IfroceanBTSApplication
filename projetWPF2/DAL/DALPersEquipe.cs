using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class DALPersEquipe
    {
        private static MySqlConnection connection;
        public DALPersEquipe()
        {
            DALConnection.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }

        public static ObservableCollection<DAOPersEquipe> selectPersEquipes()
        {
            ObservableCollection<DAOPersEquipe> l = new ObservableCollection<DAOPersEquipe>();
            string query = "SELECT * FROM personne_has_equipe;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DAOPersEquipe p = new DAOPersEquipe(reader.GetInt32(0), reader.GetInt32(1));
                l.Add(p);
            }
            reader.Close();
            return l;
        }

        public static void updatePersEquipe(PersonneViewModel p, EquipeViewModel e)
        {
            string query = "UPDATE personne_has_equipe set equipe_idEquipe=\"" + p.idPersonneProperty + "\" where personne_idPersonne=" + e.idEquipeProperty + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertPersonneEquipe(PersonneViewModel p, EquipeViewModel e)
        {
            string query = "INSERT INTO personne_has_equipe (`personne_idPersonne`, `equipe_idEquipe`) VALUES (\"" + p.idPersonneProperty + "\",\"" + e.idEquipeProperty + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }

        public static void supprimerPersonneEquipe(PersonneViewModel p, EquipeViewModel e)
        {
            string query = "DELETE FROM personne_has_equipe WHERE personne_idPersonne = \"" + p.idPersonneProperty + "\" AND equipe_idEquipe=\"" + e.idEquipeProperty + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void supprimerEquipe(EquipeViewModel e)
        {
            string query = "DELETE FROM personne_has_equipe WHERE equipe_idEquipe=\"" + e.idEquipeProperty + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void supprimerPersonne(PersonneViewModel personne)
        {
            string query = "DELETE FROM personne_has_equipe WHERE personne_idPersonne =\"" + personne.idPersonneProperty + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static DAOPersEquipe getPersonneEquipe(int id)
        {
            string query = "SELECT * FROM personne_has_equipe WHERE personne_idPersonne=" + id + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            DAOPersEquipe pers = new DAOPersEquipe(reader.GetInt32(0), reader.GetInt32(1));
            reader.Close();
            return pers;
        }
    }
}
