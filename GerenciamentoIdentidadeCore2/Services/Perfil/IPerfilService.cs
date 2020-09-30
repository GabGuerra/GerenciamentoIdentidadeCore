using GerenciamentoIdentidadeCore2.Models;
using GerenciamentoIdentidadeCore2.Models.Perfil;
using System.Collections.Generic;

namespace GerenciamentoIdentidadeCore2.Controllers
{
    public interface IPerfilService
    {
        public ResultadoVD InserirPerfilPermissao(PerfilVD perfil, int[] listaModulosPermitidos);        

        public List<PerfilVD> CarregarListaPerfis();
    }
}