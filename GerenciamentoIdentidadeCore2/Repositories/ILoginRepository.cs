using GerenciamentoIdentidadeCore2.Models;

namespace GerenciamentoIdentidadeCore2.Repositories
{
    public interface ILoginRepository
    {
        public Usuario RealizarLogin(string email, string senha);
        public void RealizarLogout();
    }
}