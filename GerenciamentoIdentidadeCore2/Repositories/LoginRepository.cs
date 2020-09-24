using GerenciamentoIdentidadeCore2.Models;
using GerenciamentoIdentidadeCore2.Models.Login;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Repositories
{
    public class LoginRepository : MySqlRepository<Usuario>, ILoginRepository
    {
        public LoginRepository(IConfiguration config) : base(config)
        {}

        public Usuario RealizarLogin(string email, string senha)
        {
            string sql = @"SELECT 
                               U.NOME_USUARIO,
                               U.CPF,
                               L.*
                           FROM

                               USUARIO U
                           INNER JOIN LOGIN L ON U.CPF = L.CPF_USUARIO
                           WHERE
                               L.SENHA = @SENHA
                           AND L.EMAIL = @EMAIL";
   
            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@SENHA", "senha");
                cmd.Parameters.AddWithValue("@EMAIL", "gabriel@teste.com");
                Usuario usuario = ObterRegistro(cmd);
                usuario.Login = new Login(email, senha);
                return usuario;
            }
        }

        public void RealizarLogout()
        {

        }

        public override Usuario PopularDados(MySqlDataReader dr)
        {
            return new Usuario
            {
                Cpf = dr["CPF"].ToString(),
                Nome = dr["NOME_USUARIO"].ToString()
            };
        }
    }
}
