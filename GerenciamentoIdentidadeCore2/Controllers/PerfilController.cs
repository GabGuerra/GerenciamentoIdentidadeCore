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
            return View();
        }

        // Cadastrar Perfil 
        [HttpPost]
        public JsonResult InserirPerfilPermissao(PerfilVD perfil, int[] listaModulosPermitidos)
        {
            return Json(_perfilService.InserirPerfilPermissao(perfil, listaModulosPermitidos));            
        }
    }
}