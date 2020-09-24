using GerenciamentoIdentidadeCore2.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Models
{
    public class Usuario : Pessoa
    {
        public Usuario(ILogin login)
        {
            Login = login;
        }
        public Usuario()
        {

        }
        public ILogin Login { get; set; }
        public Perfil perfil { get; set; }
    }
}
