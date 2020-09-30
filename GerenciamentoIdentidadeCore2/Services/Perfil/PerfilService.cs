using GerenciamentoIdentidadeCore2.Controllers;
using GerenciamentoIdentidadeCore2.Models;
using GerenciamentoIdentidadeCore2.Models.Perfil;
using GerenciamentoIdentidadeCore2.Repositories.Perfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Services.Perfil
{
    public class PerfilService: IPerfilService
    {
        public IPerfilRepository _perfilRepository { get; set; }
        public PerfilService(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }
        public ResultadoVD InserirPerfilPermissao(PerfilVD perfil, int[] listaModulosPermitidos)
        {
            ResultadoVD resultado = new ResultadoVD(true);

            try
            {
                _perfilRepository.InserirPerfil(perfil);

                foreach (var i in listaModulosPermitidos)
                {
                    _perfilRepository.InserirPerfilModulo(perfil.CodPerfil, i);
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
    }
}

