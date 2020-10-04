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
        public void EditarModulo(IModulo modulo)
        {
            var sql = @"UPDATE MODULO M SET M.NOME_MODULO = @NOME_MODULO WHERE M.COD_MODULO = @COD_MODULO";
            using (var command = new MySqlCommand(sql))
            {
                command.Parameters.AddWithValue("NOME_MODULO", modulo.NomeModulo);
                command.Parameters.AddWithValue("COD_MODULO", modulo.CodModulo);
                ExecutarComando(command);
            }
        }
        public void RemoverModulo(IModulo modulo)
        {
            var sql = @"DELETE FROM MODULO WHERE COD_MODULO = @COD_MODULO";
            using (var command = new MySqlCommand(sql))
            {
                command.Parameters.AddWithValue("COD_MODULO", modulo.CodModulo);
                ExecutarComando(command);
            }
        }
        public List<ModuloVD> CarregarListaModulo()
        {
            List<ModuloVD> lista = new List<ModuloVD>();
            var sql = @"SELECT
	                        M.COD_MODULO,
                            M.NOME_MODULO,
                            if((SELECT 1 FROM PERFIL_MODULO WHERE COD_MODULO= M.COD_MODULO GROUP BY M.COD_MODULO) > 0, 1, 0) IND_VINCULO_MODULO   
                        FROM
	                        MODULO M";
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
                NomeModulo = dr["NOME_MODULO"].ToString(),
                IndVinculoModulo = Convert.ToBoolean(dr["IND_VINCULO_MODULO"])
            };
        }
    }
}
