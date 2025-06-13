using ControleContatos.Helper;
using ControleContatos.Models;
using ControleContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepositorio usuarioRepositorio,
                               ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Se usuário estiver loago, redireciona para a Home
            if(_sessao.BuscarSessaoUsuario() !=null) return RedirectToAction("Index","Home");

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Index","Logins");  
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try 
            {
                if (ModelState.IsValid) 
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CrirarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"Senha do Usuário inválida. tente novamente ";
                    }
                    TempData["MensagemErro"] = $"Login ou Senha do Usuário inválida. tente novamente ";
                }
                return View("Index");
            }
            catch (Exception erro) 
            {
                TempData["MensagemErro"] = $"Ops,não conseguimos realizar seu Login , tente novamente,detalhe do erro :{erro.Message} ";
                return RedirectToAction("Index");
            }

        }
    }
}
