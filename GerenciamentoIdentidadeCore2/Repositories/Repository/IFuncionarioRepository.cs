using GerenciamentoIdentidadeCore2.Models.Funcionario;

namespace GerenciamentoIdentidadeCore2.Repositories.Repository
{
    public interface IFuncionarioRepository
    {
        public void InserirFuncionario(FuncionarioVD usuario);
    }
}
