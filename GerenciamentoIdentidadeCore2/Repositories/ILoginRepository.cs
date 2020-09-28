using GerenciamentoIdentidadeCore2.Models;

namespace GerenciamentoIdentidadeCore2.Repositories
{
    public interface ILoginRepository
    {
        public UsuarioVD RealizarLogin(string email, string senha);
        public void RealizarLogout();
    }
}