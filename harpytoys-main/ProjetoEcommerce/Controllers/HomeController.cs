using Microsoft.AspNetCore.Mvc;
using ProjetoEcommerce.Models;
using ProjetoEcommerce.Repositorio;

namespace ProjetoEcommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeRepositorio _homeRepositorio;

        public HomeController()
        {
            _homeRepositorio = new HomeRepositorio();
        }

        public IActionResult Index()
        {
            // Pega dados do repositório
            HomeModel model = _homeRepositorio.ObterDadosHome();

            // Envia para a view Index.cshtml
            return View(model);
        }
    }
}
