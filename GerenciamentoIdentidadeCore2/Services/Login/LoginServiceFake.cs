using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoIdentidadeCore2.Models.Login;
using GerenciamentoIdentidadeCore2.Models;

namespace GerenciamentoIdentidadeCore2.Services
{
    public class LoginServiceFake : ILoginService
    {
        public UsuarioVD RealizarLogin(string email, string senha)
        {
            return new UsuarioVD() { Cpf = "12312312321", Nome = "gabriel", Login = new LoginVD() { Email = "sadfasdfasdfads", Senha = "sadfasdfasdfasdfsd" } };
        }
    }
}
