using ControleContatos.Filters;
using ControleContatos.Models;
using ControleContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    [PaginaRetristaSomenteAdmin]

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
        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _UsuarioRepositorio.ListaPorid(id);
            return View (usuario);
        }
        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _UsuarioRepositorio.ListaPorid(id);
            return View(usuario);
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _UsuarioRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu Usuário, tente novamente ";
                }
                return RedirectToAction("Index");

            }

            catch (System.Exception erro)
            {

                TempData["MensagemSucesso"] = $"Ops, não conseguimos apagar seu Usuário,tente novamente, mais detalhe do erro:{erro.Message} ";
                return RedirectToAction("Index");

            }
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
        [HttpPost]

        public IActionResult Editar (UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel? usuario = null;
                     
                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id= usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                        Perfil = usuarioSemSenhaModel.Perfil,   
                    };

                   usuario= _UsuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops,não conseguimos cadastrar seu Usuário, tenete novamente,detalhe do erro :{erro.Message} ";
                return RedirectToAction("Index");
            }
        }

    }
}
