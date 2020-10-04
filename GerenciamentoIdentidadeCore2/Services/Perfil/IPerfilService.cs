using GerenciamentoIdentidadeCore2.Models;
using GerenciamentoIdentidadeCore2.Models.Perfil;
using System.Collections.Generic;

namespace GerenciamentoIdentidadeCore2.Controllers
{
    public interface IPerfilService
    {
        public ResultadoVD InserirPerfilPermissao(PerfilVD perfil, string listaModulosPermitidos);        
        public ResultadoVD RemoverPerfil(int codPerfil);        
        public List<PerfilVD> CarregarListaPerfis();
        public string CarregaListaPermissoesPerfil(int codPerfil);
        public ResultadoVD AtualizarPerfil(PerfilVD perfil, string listaPermissoesPerfil);
    }
}