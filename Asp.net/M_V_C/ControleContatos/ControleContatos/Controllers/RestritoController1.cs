using ControleContatos.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
