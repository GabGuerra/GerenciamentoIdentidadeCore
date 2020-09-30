using GerenciamentoIdentidadeCore2.Models.Funcionario;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace GerenciamentoIdentidadeCore2.Repositories.Repository
{
    public class UsuarioGerenciamentoRepository : MySqlRepository<FuncionarioVD>, IFuncionarioRepository
    {
        public UsuarioGerenciamentoRepository(IConfiguration config) : base(config)
        {
           
        }

        public List<FuncionarioVD> CarregarListaFuncionarios()
        {
            List<FuncionarioVD> listaFuncionario = new List<FuncionarioVD>();
            string sql = @"SELECT
	                           F.CPF,
	                           F.NOME_FUNCIONARIO,
                               P.NOME_PERFIL
                               FROM
	                           FUNCIONARIO F INNER JOIN PERFIL P ON F.COD_PERFIL = P.COD_PERFIL;";

            using (var cmd = new MySqlCommand(sql))
                listaFuncionario = ObterRegistros(cmd).ToList();

            return listaFuncionario;
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

        public override FuncionarioVD PopularDados(MySqlDataReader dr)
        {
            return new FuncionarioVD
            {
                Cpf = dr["CPF"].ToString(),
                Nome = dr["NOME_FUNCIONARIO"].ToString()                
            };
        }
    }
}
