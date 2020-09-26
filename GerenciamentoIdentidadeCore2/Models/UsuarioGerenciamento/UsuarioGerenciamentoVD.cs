using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoIdentidadeCore2.Models.Login;
using GerenciamentoIdentidadeCore2.Models.Perfil;

namespace GerenciamentoIdentidadeCore2.Models.UsuarioVD
{
    public class UsuarioGerenciamentoVD : IUsuarioGerenciamento
    {
        public UsuarioGerenciamentoVD(string cpf, string nome, PerfilVD perfil)
        {
            this.Cpf = cpf;
            this.Nome = nome;
            this.Perfil = perfil;
        }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public PerfilVD Perfil { get; set; }
    }
}
