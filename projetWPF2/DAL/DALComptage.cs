using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class DALComptage
    {
        private static MySqlConnection connection;
        public DALComptage()
        {
            DALConnection.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }
        public static ObservableCollection<DAOComptage> selectComptages()
        {
            ObservableCollection<DAOComptage> l = new ObservableCollection<DAOComptage>();
            string query = "SELECT * FROM comptage;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DAOComptage p = new DAOComptage(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2),reader.GetInt32(3), reader.GetInt32(4),reader.GetInt32(5), reader.GetInt32(6));
                l.Add(p);
            }
            reader.Close();
            return l;
        }

        public static void updateComptage(DAOComptage p)
        {
            string query = "UPDATE comptage set nb_de_part=\"" + p.nbDeParticipants + "\", coordonnees=\"" + p.coordonnees + "\", idEtude=\"" + p.idEtude + "\", idNbEspeces=\"" + p.idNbEspeces + "\", idPersonne=\"" + p.idPersonne + "\" where idComptage=" + p.idComptage + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertComptage(DAOComptage p)
        {
            string query = "INSERT INTO comptage (`nb_de_part`, `coordonnees`,`idEtude`,`idNbEspeces`,`idPlage`,`idPersonne`) VALUES (\"" + p.nbDeParticipants + "\",\"" + p.coordonnees + "\",\"" + p.idEtude + "\",\"" + p.idNbEspeces + "\",\"" + p.idPlage + "\",\"" + p.idPersonne + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }

        public static void deletedComptage(int idComptage)
        {
            string query = "DELETE FROM comptage WHERE idComptage = \"" + idComptage + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
    }
}
