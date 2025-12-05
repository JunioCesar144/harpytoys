using Microsoft.AspNetCore.Mvc;
using ProjetoEcommerce.Models;
using ProjetoEcommerce.Repositorio;
using System.Linq;

namespace ProjetoEcommerce.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoRepositorio _repo;

        public ProdutoController(ProdutoRepositorio repo)
        {
            _repo = repo;
        }

        public IActionResult Index(string nome, string codigo, int page = 1, int take = 9)
        {
            ViewBag.Nome = nome;
            ViewBag.Codigo = codigo;
            ViewBag.Page = page;
            ViewBag.Take = take;

            var produtos = _repo.ObterTodos();

            if (!string.IsNullOrWhiteSpace(nome))
                produtos = produtos.Where(p => p.Descricao.Contains(nome, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!string.IsNullOrWhiteSpace(codigo))
                produtos = produtos.Where(p => p.ID_Produto.ToString() == codigo).ToList();

            var skip = (page - 1) * take;
            var lista = produtos.Skip(skip).Take(take).ToList();

            return View(lista);
        }
    }
}
