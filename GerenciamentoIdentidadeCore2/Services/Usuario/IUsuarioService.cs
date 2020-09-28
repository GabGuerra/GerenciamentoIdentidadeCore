using GerenciamentoIdentidadeCore2.Models;
using GerenciamentoIdentidadeCore2.Models.Perfil;
using System.Collections.Generic;

namespace GerenciamentoIdentidadeCore2.Services.Usuario
{
    public interface IUsuarioService
    {
        public ResultadoVD InserirUsuario(UsuarioVD usuario);
    }
}