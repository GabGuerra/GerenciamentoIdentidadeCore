using GerenciamentoIdentidadeCore2.Models;
using GerenciamentoIdentidadeCore2.Models.Perfil;

namespace GerenciamentoIdentidadeCore2.Controllers
{
    public interface IPerfilService
    {
        public ResultadoVD InserirPerfil(IPerfil perfil);
    }
}