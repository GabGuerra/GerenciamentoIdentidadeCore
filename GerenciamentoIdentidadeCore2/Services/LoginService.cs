using GerenciamentoIdentidadeCore2.Models;
using GerenciamentoIdentidadeCore2.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _repository;
        public LoginService(ILoginRepository repository)
        {
            _repository = repository;
        }

        public Usuario RealizarLogin(string email, string senha)
        {
            return _repository.RealizarLogin(email, senha);
        }
    }
}
