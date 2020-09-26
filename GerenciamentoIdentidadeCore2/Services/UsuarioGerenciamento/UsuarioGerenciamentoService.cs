using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoIdentidadeCore2.Models;
using GerenciamentoIdentidadeCore2.Models.UsuarioVD;
using GerenciamentoIdentidadeCore2.Repositories.Repository;

namespace GerenciamentoIdentidadeCore2.Services.UsuarioGerenciamento
{
    public class UsuarioGerenciamentoService : IUsuarioGerenciamentoService
    {
        private IUsuarioGerenciamentoRepository _repository;
        public UsuarioGerenciamentoService(IUsuarioGerenciamentoRepository usuarioGerenciamentoRepository)
        {
            _repository = usuarioGerenciamentoRepository;
        }

        public ResultadoVD InserirUsuarioGerenciamento(IUsuarioGerenciamento usuario)
        {
            ResultadoVD resultado = new ResultadoVD(true);

            try
            {
                _repository.InserirUsuario(usuario);
            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = $"Não foi possível inserir o usuário. {Environment.NewLine} {ex.Message}";                
            }
            return resultado;
        }
    }
}
