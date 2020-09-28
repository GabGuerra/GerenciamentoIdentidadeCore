using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoIdentidadeCore2.Models;
using GerenciamentoIdentidadeCore2.Models.Login;
using GerenciamentoIdentidadeCore2.Services.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoIdentidadeCore2.Controllers
{
    public class UsuarioController : Controller
    {
        public IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public IActionResult CadastroUsuario()
        {
            return View("CadastroUsuario");
        }

        public JsonResult InserirUsuario(string cpf, string nome, string email, string senha)
        {
            UsuarioVD usuario = new UsuarioVD(cpf, nome, new LoginVD(senha, email));
            return Json(_usuarioService.InserirUsuario(usuario));
        }
    }
}