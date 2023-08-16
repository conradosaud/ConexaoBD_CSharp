using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexaoBD
{
    internal class ConexaoSegura
    {

        /*
         * CONEXÃO COM RECURSOS DE SEGURANÇA E PADRÃO SINGLETON
        */

        string host = "localhost";
        string banco = "07_lista_tarefas";
        string usuario = "root";
        string senha = "";

        static MySqlConnection connection;
        MySqlDataReader reader;

        public ConexaoSegura()
        {
            if( connection == null)
            {
                string connectionString = $"Server={host};Database={banco};Uid={usuario};Pwd={senha};";
                connection = new MySqlConnection(connectionString);
            }
        }

        public void executaQuery( string query )
        {

            try
            {

                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader["descricao"]);
                }

            }
            catch(Exception erro)
            {
                Console.WriteLine("Erro ao realizar consulta:");
                Console.WriteLine(erro.Message);
            }
            finally{
                connection.Dispose();
                //Console.WriteLine("Conexão com o banco fechada.");
            }
           
        }


    }
}
