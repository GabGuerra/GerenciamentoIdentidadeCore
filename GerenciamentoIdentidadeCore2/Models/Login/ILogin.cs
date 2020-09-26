using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Models.Login
{
    public interface ILogin
    {
        public string Senha { get; set; }
        public string Email { get; set; }
    }
}
