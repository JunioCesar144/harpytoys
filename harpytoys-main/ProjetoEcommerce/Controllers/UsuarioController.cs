using Microsoft.AspNetCore.Mvc;
using ProjetoEcommerce.Repositorio;

namespace ProjetoEcommerce.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(UsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            // Usa o método que já existe no repositório
            var pessoa = _usuarioRepositorio.Login(email, senha);

            if (pessoa == null)
            {
                ModelState.AddModelError("", "Email ou senha inválidos.");
                return View();
            }

            // 🔥 ALTERAÇÃO AQUI:
            // Todo mundo vai para a tela Home
            return RedirectToAction("Index", "Home");
        }
    }
}
