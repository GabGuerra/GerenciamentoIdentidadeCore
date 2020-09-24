using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Models.Login
{
    public class Login : ILogin
    {
        public Login(string Senha, string Email)
        {
            this.Senha = Senha;
            this.Email = Email;
        }
        public Login()
        {
        }
        public string Senha { get; set; }
        public string Email { get; set; }
    }
}
