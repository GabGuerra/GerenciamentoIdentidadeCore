using GerenciamentoIdentidadeCore2.Models.Login;
using GerenciamentoIdentidadeCore2.Models.Perfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Models
{
    public class Usuario
    {
        public Usuario(LoginVD login)
        {
            Login = login;
        }
        public Usuario()
        {

        }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public LoginVD Login { get; set; }        
    }
}
