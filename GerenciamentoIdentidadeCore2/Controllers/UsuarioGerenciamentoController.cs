using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoIdentidadeCore2.Models;
using GerenciamentoIdentidadeCore2.Models.UsuarioVD;
using GerenciamentoIdentidadeCore2.Services.UsuarioGerenciamento;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoIdentidadeCore2.Controllers
{
    public class UsuarioGerenciamentoController : Controller
    {
        public IUsuarioGerenciamentoService _service;
        public UsuarioGerenciamentoController(IUsuarioGerenciamentoService usuarioGerenciamentoService)
        {
            _service = usuarioGerenciamentoService;
        }
        public IActionResult Index()
        {
            return View("CadastroUsuario");
        }

        public JsonResult InserirUsuario(UsuarioGerenciamentoVD usuario) 
        {
            return Json(_service.InserirUsuarioGerenciamento(usuario));
        }

    }
}