using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoIdentidadeCore2.Models;
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
            Resultado result = new Resultado();
            result.ObjetoResultado = _service.RealizarLogin(email, senha);
            if (result.ObjetoResultado != null)
            {
                result.Sucesso = true;
                HttpContext.Session.SetString("usuarioLogado", JsonConvert.SerializeObject(result.ObjetoResultado));
            }
            result.Mensagem = result.Sucesso ? string.Empty : "Email e/ou senha incorretos.";
            return Json(result);
        }
    }
}
