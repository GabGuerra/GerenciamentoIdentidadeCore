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
        public void InserirPerfil(IPerfil perfil)
        {
            var sql = "insert into perfil (dsc_perfil) values (@perfil)";
            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@perfil", perfil.DscPerfil);
                ExecutarComando(cmd);

            };
        }
    }
}
