using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoIdentidadeCore2.Models;
using GerenciamentoIdentidadeCore2.Models.Login;
using GerenciamentoIdentidadeCore2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GerenciamentoIdentidadeCore2.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }

        public IActionResult LoginIndex()   
        {
            return View();
        }

        public JsonResult RealizarLogin(string email, string senha)
        {
            ResultadoVD result = new ResultadoVD();
            

            Usuario usuario = _service.RealizarLogin(email, senha);
            if (usuario != null)
            {
                result.Sucesso = true;
                HttpContext.Session.SetString("usuarioLogado", JsonConvert.SerializeObject(usuario));
            }
            result.Mensagem = result.Sucesso ? string.Empty : "Email e/ou senha incorretos.";
            return Json(result);
        }

        public IActionResult Home()
        {
            return View("Home/Home");
        }
    }
}
