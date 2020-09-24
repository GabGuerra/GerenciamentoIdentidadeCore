using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Models.Login
{
    public interface ILogin
    {
        string Senha { get; set; }
        string Email { get; set; }
    }
}
