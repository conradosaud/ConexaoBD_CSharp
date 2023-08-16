using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexaoBD
{
    internal class Tarefa
    {

        public int id;
        public string descricao;
        public bool status;
        public string registro;

        public Tarefa()
        {

        }

        public Tarefa( int id, string descricao, bool status, string registro)
        {
            this.id = id;
            this.descricao = descricao;
            this.status = status;
            this.registro = registro;
        }

        public List<Tarefa> buscaTodos()
        {

            string query = "SELECT * FROM tarefas;";

            DataTable resultados = ConexaoClasse.executaQuery(query);
            if( resultados == null )
                return null;

            List<Tarefa> tarefas = new List<Tarefa>();
            foreach( DataRow row in resultados.Rows )
            {
                Tarefa tarefa = carregaDados(row);
                tarefas.Add(tarefa);
            }

            return tarefas; 

        }

        public Tarefa buscaPorId( int id)
        {
            string query = "SELECT * FROM tarefas WHERE id = " + id + " LIMIT 1;";

            DataTable resultados = ConexaoClasse.executaQuery(query);
            if (resultados.Rows.Count == 0)
                return null;
            
            Tarefa tarefa = carregaDados(resultados.Rows[0] );
            return tarefa;
            
        }

        public void removePorId( int id)
        {
            string query = $"DELETE FROM tarefas WHERE id = {id};";
            ConexaoClasse.executaQuery(query);
        }

        public void insere(Tarefa tarefa)
        {
            string query = $"INSERT INTO tarefas (descricao, status) VALUES ('{tarefa.descricao}', {tarefa.status});";
            ConexaoClasse.executaQuery(query);
        }

        public void altera(Tarefa tarefa)
        {
            string query = $"UPDATE tarefas SET descricao = '{tarefa.descricao}', status = {tarefa.status} WHERE id = {tarefa.id};";
            ConexaoClasse.executaQuery(query);
        }

        private Tarefa carregaDados( DataRow row )
        {
            int id = int.Parse(row["id"].ToString());
            string descricao = row["descricao"].ToString();
            bool status = row["status"].ToString() == "1" ? true : false;
            string registro = row["registro"].ToString();

            Tarefa tarefa = new Tarefa(id, descricao, status, registro);
            return tarefa;
        }

    }
}
