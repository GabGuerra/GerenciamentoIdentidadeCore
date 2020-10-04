using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Models.Modulo
{
    public interface IModulo
    {
        public int CodModulo { get; set; }
        public string NomeModulo { get; set; }
        public bool IndVinculoModulo { get; set; }
    }
}
