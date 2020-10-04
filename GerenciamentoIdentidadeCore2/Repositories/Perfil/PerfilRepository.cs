using GerenciamentoIdentidadeCore2.Models.Perfil;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Repositories.Perfil
{
    public class PerfilRepository : MySqlRepository<PerfilVD>, IPerfilRepository
    {
        public PerfilRepository(IConfiguration config) : base(config)
        {
        }
        public void InserirPerfil(PerfilVD perfil)
        {
            var sql = "INSERT INTO PERFIL (NOME_PERFIL) VALUES (@NOME_PERFIL)";
            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@NOME_PERFIL", perfil.NomePerfil);
                ExecutarComando(cmd);
            };
        }

        public void InserirPerfilModulo(int codPerfil, int codModulo)
        {
            var sql = "INSERT INTO PERFIL_MODULO VALUES (";
            if (codPerfil > 0)
                sql += codPerfil;
            else
                sql += "(SELECT MAX(COD_PERFIL) FROM PERFIL)";


            sql += ",@COD_MODULO)";
            using (var cmd = new MySqlCommand(sql))
            {
                //cmd.Parameters.AddWithValue("@COD_PERFIL", codPerfil);
                cmd.Parameters.AddWithValue("@COD_MODULO", codModulo);

                ExecutarComando(cmd);
            };
        }

        public List<PerfilVD> CarregarListaPerfis()
        {
            List<PerfilVD> listaPerfil = new List<PerfilVD>();
            string sql = @"SELECT
	                           P.COD_PERFIL,
	                           P.NOME_PERFIL,
                                if((SELECT 1 FROM FUNCIONARIO WHERE COD_PERFIL= P.COD_PERFIL GROUP BY P.COD_PERFIL) > 0, 1, 0) IND_VINCULO_FUNCIONARIO        
                           FROM
	                           PERFIL P";

            using (var cmd = new MySqlCommand(sql))
                listaPerfil = ObterRegistros(cmd).ToList();

            return listaPerfil;
        }


        public override PerfilVD PopularDados(MySqlDataReader dr)
        {
            return new PerfilVD
            {
                CodPerfil = Convert.ToInt32(dr["COD_PERFIL"]),
                IndVinculoFuncionario = Convert.ToBoolean(dr["IND_VINCULO_FUNCIONARIO"]),
                NomePerfil = dr["NOME_PERFIL"].ToString()
            };
        }
        public override string PopularRegistroString(MySqlDataReader dr, string coluna)
        {
            return dr[coluna].ToString();
        }

        public void RemoverPerfil(int codPerfil)
        {
            var sql = "DELETE FROM PERFIL WHERE COD_PERFIL = @COD_PERFIL";
            using (var cmd = new MySqlCommand(sql))
            {

                cmd.Parameters.AddWithValue("@COD_PERFIL", codPerfil);
                ExecutarComando(cmd);
            };
        }
        public void RemoverPermissoesPerfil(int codPerfil)
        {
            var sql = "DELETE FROM PERFIL_MODULO WHERE COD_PERFIL = @COD_PERFIL";
            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@COD_PERFIL", codPerfil);
                ExecutarComando(cmd);
            };
        }

        public void AtualizarPerfil(PerfilVD perfil)
        {
            var sql = "UPDATE PERFIL SET NOME_PERFIL = @NOME_PERFIL WHERE COD_PERFIL = @COD_PERFIL";
            using (var cmd = new MySqlCommand(sql))
            {

                cmd.Parameters.AddWithValue("@COD_PERFIL", perfil.CodPerfil);
                cmd.Parameters.AddWithValue("@NOME_PERFIL", perfil.NomePerfil);
                ExecutarComando(cmd);
            };
        }

        public string CarregaListaPermissoesPerfil(int codPerfil)
        {
            string listaPermissoesPerfil = "";
            string sql = @"SELECT
	                           PM.COD_MODULO	                           
                           FROM
	                           PERFIL_MODULO PM WHERE PM.COD_PERFIL= @COD_PERFIL";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@COD_PERFIL", codPerfil);
                listaPermissoesPerfil = ObterRegistroStrings(cmd, "COD_MODULO");
            }


            return listaPermissoesPerfil;
        }
    }
}
