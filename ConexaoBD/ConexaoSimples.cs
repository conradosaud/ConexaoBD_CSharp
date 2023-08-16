using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexaoBD
{
    internal class ConexaoSimples
    {

        /*
            EXEMPLO SIMLES DE CONEXÃO COM O BANCO DE DADOS 
        */

        string host = "localhost";
        string banco = "07_lista_tarefas";
        string usuario = "root";
        string senha = "";

        MySqlConnection connection;
        MySqlDataReader reader;

        public ConexaoSimples()
        {
            string connectionString = $"Server={host};Database={banco};Uid={usuario};Pwd={senha};";
            connection = new MySqlConnection(connectionString);
        }

        public void executaQuery( string query )
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader["descricao"]);
                //Console.WriteLine(reader.GetString(1));
            }

            connection.Clone();

        }


    }
}
