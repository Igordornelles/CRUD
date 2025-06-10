using ControleContatos.Models;
using ControleContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _UsuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio UsuarioRepositorio)
        {
            _UsuarioRepositorio = UsuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _UsuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _UsuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops,não conseguimos Usuario seu contato, tente novamente,detalhe do erro :{erro.Message} ";
                return RedirectToAction("Index");
            }
        }

    }
}
