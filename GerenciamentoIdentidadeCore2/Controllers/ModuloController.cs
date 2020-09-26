using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoIdentidadeCore2.Models.Modulo;
using GerenciamentoIdentidadeCore2.Services.Modulo;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoIdentidadeCore2.Controllers
{
    public class ModuloController : Controller
    {

        public IModuloService _moduloService;
        public ModuloController(IModuloService moduloService)
        {
            _moduloService = moduloService;
        }

        public IActionResult Index()
        {
            return View("ModuloIndex");
        }

        public JsonResult InserirModulo(ModuloVD modulo)
        {
            return Json(_moduloService.InserirModulo(modulo));
        }
    }
}