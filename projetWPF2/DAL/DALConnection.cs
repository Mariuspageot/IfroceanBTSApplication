using System;

using MySql.Data.MySqlClient;

namespace projetWPF2
{
    class DALConnection
    {
        private static string server;
        private static string database;
        private static string uid;
        private static string password;
        public static MySqlConnection connection;

        public static Boolean OpenConnection()
        {
            if (connection == null) //  si la connexion est déjà ouverte, il ne la refera pas 
            {

                server = "127.0.0.1";
                database = "projettrans";
                uid = "ifrocean";
                password = "ifrocean";
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                connection = new MySqlConnection(connectionString);
                connection.Open();
  

            }
            return true;
        }
    }
}
