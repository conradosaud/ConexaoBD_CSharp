﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexaoBD
{
    internal class ConexaoClasse
    {

        /*
         * EXEMPLO DE CONEXÃO GENÉRICA QUE PODE SER INTEGRADA COM QUALQUER CLASSE
        */

        const string host = "localhost";
        const string banco = "07_lista_tarefas";
        const string usuario = "root";
        const string senha = "";

        public static MySqlConnection connection = 
            new MySqlConnection($"Server={host};Database={banco};Uid={usuario};Pwd={senha};");

        public static DataTable executaQuery( string query )
        {

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader read = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(read);
                return dataTable;
            }
            catch(Exception erro)
            {
                Console.WriteLine("Erro ao realizar consulta:");
                Console.WriteLine(erro.Message);
                return null;
            }
            finally{
                connection.Dispose();
            }
           
        }


    }
}
