using GerenciamentoIdentidadeCore2.Models.Perfil;

namespace GerenciamentoIdentidadeCore2.Models.Funcionario
{
    public class FuncionarioVD 
    {
        public FuncionarioVD(string cpf, string nome, PerfilVD perfil)
        {
            this.Cpf = cpf;
            this.Nome = nome;
            this.Perfil = perfil;
        }
        public FuncionarioVD()
        {
        }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public PerfilVD Perfil { get; set; }
    }
}
