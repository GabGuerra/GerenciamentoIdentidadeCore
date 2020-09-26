using GerenciamentoIdentidadeCore2.Models.Modulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Repositories.Modulo
{
    public interface IModuloRepository 
    {
        public void InserirModulo(IModulo modulo);
    }
}
