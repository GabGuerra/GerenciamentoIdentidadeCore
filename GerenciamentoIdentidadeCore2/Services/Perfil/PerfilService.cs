using GerenciamentoIdentidadeCore2.Controllers;
using GerenciamentoIdentidadeCore2.Models;
using GerenciamentoIdentidadeCore2.Models.Perfil;
using GerenciamentoIdentidadeCore2.Repositories.Perfil;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Services.Perfil
{
    public class PerfilService : IPerfilService
    {
        public IPerfilRepository _perfilRepository { get; set; }

        public PerfilService(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }
        public ResultadoVD InserirPerfilPermissao(PerfilVD perfil, string listaModulosPermitidos)
        {
            ResultadoVD resultado = new ResultadoVD(true);

            try
            {
                _perfilRepository.InserirPerfil(perfil);
                if (!String.IsNullOrEmpty(listaModulosPermitidos))
                {
                    var aux = listaModulosPermitidos.Split(",");
                    foreach (var i in aux)
                    {
                        if (String.IsNullOrEmpty(i))
                        {
                            continue;
                        }
                        _perfilRepository.InserirPerfilModulo(perfil.CodPerfil, Convert.ToInt32(i));
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Mensagem = ex.Message;
                resultado.Sucesso = false;
            }

            return resultado;
        }

        public List<PerfilVD> CarregarListaPerfis()
        {
            return _perfilRepository.CarregarListaPerfis();
        }

        public ResultadoVD AtualizarPerfil(PerfilVD perfil, string listaPermissoesPerfil)
        {
            ResultadoVD resultado = new ResultadoVD(true);

            try
            {
                if (resultado.Sucesso)
                {
                    _perfilRepository.AtualizarPerfil(perfil);
                    _perfilRepository.RemoverPermissoesPerfil(perfil.CodPerfil);
                    if (!String.IsNullOrEmpty(listaPermissoesPerfil))
                    {
                        var aux = listaPermissoesPerfil.Split(",");
                        foreach (var i in aux)
                        {
                            if (String.IsNullOrEmpty(i))
                            {
                                continue;
                            }
                            _perfilRepository.InserirPerfilModulo(perfil.CodPerfil, Convert.ToInt32(i));
                        }
                    }
                    else
                        return resultado;

                }
            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = $"Não foi possível atualizar o Perfil. {Environment.NewLine} {ex.Message}";
            }
            return resultado;
        }
        public ResultadoVD RemoverPerfil(int codPerfil)
        {
            ResultadoVD resultado = new ResultadoVD(true);

            try
            {
                _perfilRepository.RemoverPermissoesPerfil(codPerfil);
                _perfilRepository.RemoverPerfil(codPerfil);
            }
            catch (Exception ex)
            {

                if (ex.Message.Equals("Cannot delete or update a parent row: a foreign key constraint fails (`gerenciamento_identidade`.`perfil_modulo`, CONSTRAINT `perfil_modulo_ibfk_1` FOREIGN KEY (`COD_PERFIL`) REFERENCES `perfil` (`COD_PERFIL`))"))
                {
                    resultado.Mensagem = "Atenção! Esse Perfil possui vinculo com algum modulo, devincule o modulo do perfil e tente novamente.";
                };
                resultado.Sucesso = false;
            }

            return resultado;
        }

        public string CarregaListaPermissoesPerfil(int codPerfil)
        {

            return _perfilRepository.CarregaListaPermissoesPerfil(codPerfil);
        }
    }
}

