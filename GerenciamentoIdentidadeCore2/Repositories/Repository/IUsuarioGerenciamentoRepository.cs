using GerenciamentoIdentidadeCore2.Models.UsuarioVD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Repositories.Repository
{
    public interface IUsuarioGerenciamentoRepository
    {
        public void InserirUsuario(IUsuarioGerenciamento usuario);
    }
}
