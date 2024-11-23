using apiTestDapp.MODEL;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;


namespace DL.SO.Project.Web.UI.Repositories
{
    public interface ITarefaDAO
    {
        IEnumerable<TarefaModel> ListarTarefas();
        int ColocarTarefa(TarefaModel tarefa);
        public string DeletarTarefa(int id);
    }

    public class TarefaDAO : ITarefaDAO
    {
        private readonly IDbConnection _dbConnection;


        public TarefaDAO(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public IEnumerable<TarefaModel> ListarTarefas()
        {


            var sql = "SELECT * FROM Tarefas";
            return _dbConnection.Query<TarefaModel>(sql);



        }
        public int ColocarTarefa(TarefaModel tarefa)
        {
            var sql = "INSERT INTO Tarefas (Descricao, Concluida) VALUES (@descricao, @concluida)";
            return _dbConnection.Execute(sql, new { tarefa.descricao, tarefa.concluida });
        }
        public string DeletarTarefa(int id)
        {
            var sql = "DELETE FROM Tarefas WHERE Id = @id";
            var rowsAffected = _dbConnection.Execute(sql, new { id });

            if (rowsAffected > 0)
            {
                return "Tarefa deletada com sucesso.";
            }
            else
            {
                return "Nenhuma tarefa foi encontrada com o ID fornecido.";
            }
        }

    }
}