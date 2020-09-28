using GerenciamentoIdentidadeCore2.Models;
using GerenciamentoIdentidadeCore2.Repositories;
using GerenciamentoIdentidadeCore2.Repositories.Usuario;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Services.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public ResultadoVD InserirUsuario(UsuarioVD usuario)
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
