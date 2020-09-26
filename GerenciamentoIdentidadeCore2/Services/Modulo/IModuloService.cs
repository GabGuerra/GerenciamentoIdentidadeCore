using GerenciamentoIdentidadeCore2.Models;
using GerenciamentoIdentidadeCore2.Models.Modulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Services.Modulo
{
    public interface IModuloService
    {
        public ResultadoVD InserirModulo(IModulo modulo);
    }
}
