
using GerenciamentoIdentidadeCore2.Models.Funcionario;
using GerenciamentoIdentidadeCore2.Models.Perfil;
using GerenciamentoIdentidadeCore2.Services.Funcionario;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoIdentidadeCore2.Controllers
{
    public class FuncionarioController : Controller
    {
        public IFuncionarioService _serviceFuncionario;
        public IPerfilService _servicePerfil;
        public FuncionarioController(IFuncionarioService serviceFuncionario, IPerfilService servicePerfil)
        {
            _serviceFuncionario = serviceFuncionario;
            _servicePerfil = servicePerfil;
        }
        public IActionResult Index()
        {
            ViewBag.ListaPerfis = _servicePerfil.CarregarListaPerfis();
            ViewBag.ListaFuncionarios = _serviceFuncionario.CarregarListaFuncionarios();

            return View("CadastroFuncionario");
        }

        public JsonResult InserirFuncionario(string cpf, string nome, int codPerfil)
        {
            FuncionarioVD funcionario = new FuncionarioVD(cpf, nome, new PerfilVD(codPerfil));
            return Json(_serviceFuncionario.InserirFuncionario(funcionario));
        }  
        public JsonResult AtualizarFuncionario(string cpf, string nome, int codPerfil)
        {
            FuncionarioVD funcionario = new FuncionarioVD(cpf, nome, new PerfilVD(codPerfil));
            return Json(_serviceFuncionario.AtualizarFuncionario(funcionario));
        }   
        public JsonResult RemoverFuncionario(string cpf)
        {          
            return Json(_serviceFuncionario.RemoverFuncionario(cpf));
        }
        public IActionResult GridFuncionarios()
        {
            return PartialView("GridFuncionarios");
        }

    }
}