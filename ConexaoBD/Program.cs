// See https://aka.ms/new-console-template for more information
using ConexaoBD;

Console.WriteLine("Hello, World!");

ConexaoSimples conexao = new ConexaoSimples();
//conexao.executaQuery("SELECT * FROM tarefas;");
ConexaoSegura conexao2 = new ConexaoSegura();
//conexao2.executaQuery("SELECT * FROM tarefas;");

Tarefa tarefa = new Tarefa();
List<Tarefa> tarefas = tarefa.buscaTodos();
if( tarefas != null)
{
    for (int i = 0; i < tarefas.Count; i++)
    {
        Console.WriteLine(tarefas[i].id + " - " + tarefas[i].descricao);
    }
}

Console.WriteLine("-------------------");
Tarefa tarefaEncontrada = tarefa.buscaPorId(5);
if( tarefaEncontrada == null)
{
    Console.WriteLine("Tarefa não encontrada...");
}
else
{
    Console.WriteLine(tarefaEncontrada.id +" - "+ tarefaEncontrada.descricao);
}

Console.WriteLine("-------------------");
tarefa.removePorId(1);
Console.WriteLine("Usuario 1 removido!");

Console.WriteLine("-------------------");
tarefa.insere(new Tarefa(0, "Teste novo", false, ""));
Console.WriteLine("Novo usuário inserido!");

Console.WriteLine("-------------------");
tarefa.altera(new Tarefa(9, "Melhorado", true, ""));