using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoIdentidadeCore2.Models;
using GerenciamentoIdentidadeCore2.Models.Modulo;
using GerenciamentoIdentidadeCore2.Repositories.Modulo;

namespace GerenciamentoIdentidadeCore2.Services.Modulo
{
    public class ModuloService : IModuloService
    {
        public IModuloRepository _moduloRepository { get; set; }
        public ModuloService(IModuloRepository moduloRepository)
        {
            _moduloRepository = moduloRepository;
        }
        public ResultadoVD InserirModulo(IModulo modulo)
        {
            ResultadoVD resultado = new ResultadoVD(true);

            try
            {
                _moduloRepository.InserirModulo(modulo);
            }
            catch (Exception ex)
            {
                resultado.Mensagem = ex.Message;
                resultado.Sucesso = false;
            }            

            return resultado;
        }

        public List<ModuloVD> CarregarListaModulo() 
        {
            return _moduloRepository.CarregarListaModulo();
        }

    }
}
