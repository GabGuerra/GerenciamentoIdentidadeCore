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
        public Resultado InserirPerfil(IPerfil perfil)
        {
            Resultado resultado = new Resultado(true);

            try
            {
                _perfilRepository.InserirPerfil(perfil);
            }
            catch (Exception ex)
            {
                resultado.Mensagem = ex.Message;
                resultado.Sucesso = false;
            }

            return resultado;
        }
    }
}

