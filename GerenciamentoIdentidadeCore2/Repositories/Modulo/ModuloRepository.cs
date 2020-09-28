using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoIdentidadeCore2.Models.Modulo;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace GerenciamentoIdentidadeCore2.Repositories.Modulo
{
    public class ModuloRepository : MySqlRepository<ModuloVD>, IModuloRepository
    {
        public ModuloRepository(IConfiguration config) : base(config)
        {
        }

        public void InserirModulo(IModulo modulo)
        {
            var sql = @"INSERT INTO MODULO 
                            (NOME_MODULO) 
                        VALUES
                            (@NOME_MODULO)";
            using (var command = new MySqlCommand(sql))
            {
                command.Parameters.AddWithValue("NOME_MODULO", modulo.NomeModulo);
                ExecutarComando(command);
            }
        }

        public List<ModuloVD> CarregarListaModulo()
        {
            List<ModuloVD> lista = new List<ModuloVD>();
            var sql = @"SELECT
	                        COD_MODULO,
                            NOME_MODULO
                        FROM
	                        MODULO";
            using (var cmd = new MySqlCommand(sql))
            {
                lista = ObterRegistros(cmd).ToList();
            }

            return lista;
        }

        public override ModuloVD PopularDados(MySqlDataReader dr)
        {
            return new ModuloVD
            {
                CodModulo = Convert.ToInt32(dr["COD_MODULO"]),
                NomeModulo = dr["NOME_MODULO"].ToString()
            };
        }
    }
}
