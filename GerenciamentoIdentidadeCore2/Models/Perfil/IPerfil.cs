using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Models.Perfil
{
    public interface IPerfil

    {
        public int Perfil { get; set; }
        public string DscPerfil { get; set; }
    }
}
