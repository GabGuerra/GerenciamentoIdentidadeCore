using GerenciamentoIdentidadeCore2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Services
{
    public interface ILoginService
    {
        UsuarioVD RealizarLogin(string email, string senha);
    }
}
