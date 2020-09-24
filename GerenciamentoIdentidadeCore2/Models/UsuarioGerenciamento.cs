using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Models
{
    public class UsuarioGerenciamento : Pessoa
    {
        public UsuarioGerenciamento()
        {            
        }
        public Perfil Perfil { get; set; }
    }
}
