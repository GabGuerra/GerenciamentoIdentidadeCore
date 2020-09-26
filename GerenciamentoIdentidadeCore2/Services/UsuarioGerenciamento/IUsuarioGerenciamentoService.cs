using GerenciamentoIdentidadeCore2.Models;
using GerenciamentoIdentidadeCore2.Models.UsuarioVD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Services.UsuarioGerenciamento
{
    public interface IUsuarioGerenciamentoService
    {
        public ResultadoVD InserirUsuarioGerenciamento(IUsuarioGerenciamento usuario);
    }
}
