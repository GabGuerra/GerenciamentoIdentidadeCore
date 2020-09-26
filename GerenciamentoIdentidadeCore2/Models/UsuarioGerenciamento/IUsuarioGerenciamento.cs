using GerenciamentoIdentidadeCore2.Models.Login;
using GerenciamentoIdentidadeCore2.Models.Perfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Models.UsuarioVD
{
    public interface IUsuarioGerenciamento
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public PerfilVD Perfil { get; set; }
    }
}
