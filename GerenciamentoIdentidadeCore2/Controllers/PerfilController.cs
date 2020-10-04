using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoIdentidadeCore2.Models.Perfil;
using GerenciamentoIdentidadeCore2.Services.Modulo;
using GerenciamentoIdentidadeCore2.Services.Perfil;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoIdentidadeCore2.Controllers
{
    public class PerfilController : Controller
    {
        public IPerfilService _perfilService;
        public IModuloService _moduloService;  
        public PerfilController(IPerfilService perfilService, IModuloService moduloService)
        {
            _perfilService = perfilService;
            _moduloService = moduloService;
        }

        //Tela inicial de Cadastro de Perfil
        public ActionResult CadastroPerfil()
        {
            ViewBag.ListaModulos = _moduloService.CarregarListaModulo();
            ViewBag.ListaPerfis = _perfilService.CarregarListaPerfis();
            return View();
        }

        // Cadastrar Perfil 
        public JsonResult InserirPerfilPermissao(string NomePerfil, string listaModulosPermitidos)
        {
            PerfilVD perfil = new PerfilVD() { NomePerfil = NomePerfil };
            return Json(_perfilService.InserirPerfilPermissao(perfil, listaModulosPermitidos));
        }
        // Atualizar Perfil
        public JsonResult AtualizarPerfil(int codPerfil, string nomePerfil, string listaPermissoesPerfil = "")
        {
            PerfilVD perfil = new PerfilVD(codPerfil,nomePerfil);
            return Json(_perfilService.AtualizarPerfil(perfil, listaPermissoesPerfil));
        }
        // Remover Perfil
        public JsonResult RemoverPerfil(int codPerfil)
        {
            return Json(_perfilService.RemoverPerfil(codPerfil));
        }
        public IActionResult GridPerfil()
        {
            ViewBag.ListaPerfis = _perfilService.CarregarListaPerfis();
            //ViewBag.ListaPerfisModulos = _perfilService.CarregaListaPermissoesPerfil(codPerfil);
            return PartialView("GridPerfils");
        }

        public JsonResult CarregaListaPermissoesPerfil(int codPerfil) {

            return Json(_perfilService.CarregaListaPermissoesPerfil(codPerfil));
        }
    }
}