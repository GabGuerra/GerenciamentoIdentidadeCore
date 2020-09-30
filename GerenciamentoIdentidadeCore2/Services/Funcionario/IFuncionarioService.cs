using GerenciamentoIdentidadeCore2.Models;
using GerenciamentoIdentidadeCore2.Models.Funcionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Services.Funcionario
{
    public interface IFuncionarioService
    {
        public ResultadoVD InserirFuncionario(FuncionarioVD funcionario);
        public ResultadoVD AtualizarFuncionario(FuncionarioVD funcionario);
        public ResultadoVD RemoverFuncionario(string cpf);
        public List<FuncionarioVD> CarregarListaFuncionarios();
    }
}
