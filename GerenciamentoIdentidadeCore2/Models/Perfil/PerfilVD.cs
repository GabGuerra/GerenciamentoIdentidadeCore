using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Models.Perfil
{

    public class PerfilVD
    {
        public PerfilVD()
        {
        }
        public PerfilVD(int codPerfil)
        {
            CodPerfil = codPerfil;
        }
        public PerfilVD(int codPerfil, string nomePerfil)
        {
            CodPerfil = codPerfil;
            NomePerfil = nomePerfil;
        }
        public int CodPerfil { get; set; }
        public string NomePerfil { get; set; }
        //indica se possui vinculo com algum funcionario para permitir exclusao caso nao haja
        public bool IndVinculoFuncionario { get; set; }
    }
}
