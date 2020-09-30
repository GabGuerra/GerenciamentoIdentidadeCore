using GerenciamentoIdentidadeCore2.Models.Funcionario;
using GerenciamentoIdentidadeCore2.Models.Perfil;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
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
                               F.COD_PERFIL
                               FROM
	                           FUNCIONARIO F INNER JOIN PERFIL P ON F.COD_PERFIL = P.COD_PERFIL
                               ORDER BY F.NOME_FUNCIONARIO; ";

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
        public void AtualizarFuncionario(FuncionarioVD funcionario)
        {
            string sql = @"UPDATE FUNCIONARIO
                                SET NOME_FUNCIONARIO = @NOME_FUNCIONARIO,
                                    COD_PERFIL = @COD_PERFIL
                                 WHERE CPF= @CPF";
            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("CPF", funcionario.Cpf);
                cmd.Parameters.AddWithValue("NOME_FUNCIONARIO", funcionario.Nome);
                cmd.Parameters.AddWithValue("COD_PERFIL", funcionario.Perfil.CodPerfil);
                ExecutarComando(cmd);
            }
        }
        public void RemoverFuncionario(string cpf)
        {
            string sql = @"DELETE FROM FUNCIONARIO WHERE CPF= @CPF";
            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("CPF", cpf);         
                ExecutarComando(cmd);
            }
        }
        public override FuncionarioVD PopularDados(MySqlDataReader dr)
        {
            PerfilVD perfil = new PerfilVD();
            perfil.CodPerfil = Convert.ToInt32(dr["COD_PERFIL"]);
            return new FuncionarioVD
            {
                Cpf = dr["CPF"].ToString(),
                Nome = dr["NOME_FUNCIONARIO"].ToString()  ,                
                Perfil = perfil
            };
        }

     
    }
}
