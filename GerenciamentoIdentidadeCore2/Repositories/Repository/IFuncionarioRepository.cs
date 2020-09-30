using GerenciamentoIdentidadeCore2.Models.Funcionario;
using System.Collections.Generic;

namespace GerenciamentoIdentidadeCore2.Repositories.Repository
{
    public interface IFuncionarioRepository
    {
        public void InserirFuncionario(FuncionarioVD usuario);
        public void AtualizarFuncionario(FuncionarioVD usuario);
        public void RemoverFuncionario(string cpf);
        public List<FuncionarioVD> CarregarListaFuncionarios();
    }
}
