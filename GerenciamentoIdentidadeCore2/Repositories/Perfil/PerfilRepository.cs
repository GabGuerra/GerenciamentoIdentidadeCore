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
            var sql = "INSERT INTO PERFIL_MODULO (@COD_PERFIL,@COD_MODULO)";
            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@COD_PERFIL", codPerfil);
                cmd.Parameters.AddWithValue("@COD_MODULO", codModulo);

                ExecutarComando(cmd);
            };
        }

        public List<PerfilVD> CarregarListaPerfis()
        {
            List<PerfilVD> listaPerfil = new List<PerfilVD>();
            string sql = @"SELECT
	                           COD_PERFIL,
	                           NOME_PERFIL
                           FROM
	                           PERFIL";

            using (var cmd = new MySqlCommand(sql))
                listaPerfil = ObterRegistros(cmd).ToList();

            return listaPerfil;
        }

        public override PerfilVD PopularDados(MySqlDataReader dr)
        {
            return new PerfilVD
            {
                CodPerfil = Convert.ToInt32(dr["COD_PERFIL"]),
                NomePerfil = dr["NOME_PERFIL"].ToString()
            };
        }
    }
}
