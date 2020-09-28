using GerenciamentoIdentidadeCore2.Models;
using GerenciamentoIdentidadeCore2.Models.Login;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Repositories.Usuario
{
    public class UsuarioRepository : MySqlRepository<UsuarioVD>, IUsuarioRepository
    {
        public UsuarioRepository(IConfiguration config) : base(config)
        {}

        public void InserirUsuario(UsuarioVD usuario)
        {
            string sql = @"
                        INSERT INTO USUARIO(CPF,NOME_USUARIO) VALUES (@CPF,@NOME_USUARIO);
                        INSERT INTO LOGIN(EMAIL,SENHA,CPF_USUARIO) VALUES (@EMAIL,@SENHA,@CPF);";

            try
            {
                using (var cmd = new MySqlCommand(sql))
                {
                    cmd.Parameters.AddWithValue("@CPF", usuario.Cpf);
                    cmd.Parameters.AddWithValue("@NOME_USUARIO", usuario.Nome);
                    cmd.Parameters.AddWithValue("@EMAIL", usuario.Login.Email);
                    cmd.Parameters.AddWithValue("@SENHA", usuario.Login.Senha);                    

                    ExecutarComando(cmd);
                }
            }
            catch
            {
                throw;
            }            
        }
    
    }
}
