using apiTestDapp.MODEL;
using DL.SO.Project.Web.UI.Repositories;

namespace apiTestDapp.SERVICES
{
    public class TarefaService
    {
        private readonly ITarefaDAO _tarefaDAO;
       public TarefaService(ITarefaDAO tarefaDAO)
        {
            _tarefaDAO = tarefaDAO;
        }
        public IEnumerable<TarefaModel> ListaTarefa()
        {
            return _tarefaDAO.ListarTarefas();
        }
        public bool ColocarTarefa(TarefaModel tarefa) 
        {
            
            if (string.IsNullOrEmpty(tarefa.descricao) )
            {
                return false; 
            }

            
            int linhasAfetadas = _tarefaDAO.ColocarTarefa(tarefa);
            return linhasAfetadas > 0;
        }
        public string DeletarTarefa(int id)
        {
            if (id <= 0)
            {
                return "Tarefa deletada";

            }
            return _tarefaDAO.DeletarTarefa(id);
        }
    }
}
