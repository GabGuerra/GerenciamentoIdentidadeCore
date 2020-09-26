using GerenciamentoIdentidadeCore2.Models.UsuarioVD;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Repositories.Repository
{
    public class UsuarioGerenciamentoRepository : MySqlRepository<UsuarioGerenciamentoVD>, IUsuarioGerenciamentoRepository
    {
        public UsuarioGerenciamentoRepository(IConfiguration config) : base(config)
        {

        }

        public void InserirUsuario(IUsuarioGerenciamento usuario)
        {
            string sql = @"INSERT INTO USUARIO
                                (CPF, NOME_USUARIO)
                           VALUES
                                (@CPF,@NOME_USUARIO)";            
            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("CPF", usuario.Cpf);
                cmd.Parameters.AddWithValue("NOME_USUARIO", usuario.Nome);
                ExecutarComando(cmd);
            }
        }
    }
}
