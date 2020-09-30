using GerenciamentoIdentidadeCore2.Models.Funcionario;
using System.Collections.Generic;

namespace GerenciamentoIdentidadeCore2.Repositories.Repository
{
    public interface IFuncionarioRepository
    {
        public void InserirFuncionario(FuncionarioVD usuario);
        public List<FuncionarioVD> CarregarListaFuncionarios();
    }
}
