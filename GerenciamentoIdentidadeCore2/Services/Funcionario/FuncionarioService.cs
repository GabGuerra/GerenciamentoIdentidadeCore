﻿using System;
using GerenciamentoIdentidadeCore2.Models;
using GerenciamentoIdentidadeCore2.Models.Funcionario;
using GerenciamentoIdentidadeCore2.Repositories.Repository;

namespace GerenciamentoIdentidadeCore2.Services.Funcionario
{
    public class FuncionarioService : IFuncionarioService
    {
        private IFuncionarioRepository _repository;
        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _repository = funcionarioRepository;
        }

        public ResultadoVD InserirFuncionario(FuncionarioVD funcionario)
        {
            ResultadoVD resultado = new ResultadoVD(true);

            try
            {
                //Valida os campos do usuário
                resultado = ValidaFuncionario(funcionario);
                if (resultado.Sucesso)
                    _repository.InserirFuncionario(funcionario);
                else
                    return resultado;

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = $"Não foi possível inserir o usuário. {Environment.NewLine} {ex.Message}";
            }
            return resultado;
        }

        public ResultadoVD ValidaFuncionario(FuncionarioVD funcionario)
        {
            ResultadoVD resultado = new ResultadoVD(true);

            if (!string.IsNullOrEmpty(funcionario.Cpf))
                funcionario.Cpf = funcionario.Cpf.Replace(".", string.Empty).Replace("-", string.Empty);
            if (string.IsNullOrEmpty(funcionario.Nome))
                resultado.Mensagem = "É necessário informar o nome do funcionário";
            if(funcionario.Perfil.CodPerfil == 0)
                resultado.Mensagem = "É necessário informar perfil do funcionário";

            resultado.Sucesso = string.IsNullOrEmpty(resultado.Mensagem);

            return resultado;
        }
    }
}
