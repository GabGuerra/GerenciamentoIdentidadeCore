using GerenciamentoIdentidadeCore2.Models.Funcionario;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace GerenciamentoIdentidadeCore2.Repositories.Repository
{
    public class UsuarioGerenciamentoRepository : MySqlRepository<FuncionarioVD>, IFuncionarioRepository
    {
        public UsuarioGerenciamentoRepository(IConfiguration config) : base(config)
        {

        }

        public void InserirFuncionario(FuncionarioVD funcionario)
        {
            string sql = @"INSERT INTO FUNCIONARIO
                                (CPF, NOME_FUNCIONARIO, COD_PERFIL)
                           VALUES
                                (@CPF,@NOME_FUNCIONARIO, @COD_PERFIL)";            
            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("CPF", funcionario.Cpf);
                cmd.Parameters.AddWithValue("NOME_FUNCIONARIO", funcionario.Nome);
                cmd.Parameters.AddWithValue("COD_PERFIL", funcionario.Perfil.CodPerfil);

                ExecutarComando(cmd);
            }
        }          
    }
}
