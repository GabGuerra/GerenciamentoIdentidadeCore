using GerenciamentoIdentidadeCore2.Models;

namespace GerenciamentoIdentidadeCore2.Repositories.Usuario
{
    public interface IUsuarioRepository
    {
        public void InserirUsuario(UsuarioVD usuario);
    }
}