using Microsoft.AspNetCore.Mvc;
using ProjetoEcommerce.Models;
using ProjetoEcommerce.Repositorio;

namespace ProjetoEcommerce.Controllers
{
    public class CadProdutoController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly CadProdutoRepositorio _repositorio;

        public CadProdutoController(IWebHostEnvironment environment, CadProdutoRepositorio repositorio)
        {
            _environment = environment;
            _repositorio = repositorio;
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View("CadProduto"); // 👈 MOSTRAR A VIEW CadProduto.cshtml
        }

        [HttpPost]
        public IActionResult Cadastro(CadProduto produto, IFormFile imagem)
        {
            // Gerar ID manualmente já que o banco não tem AUTO_INCREMENT
            produto.ID_Produto = new Random().Next(1000, 9999);

            if (imagem != null && imagem.Length > 0)
            {
                string pasta = Path.Combine(_environment.WebRootPath, "img/produtos");

                if (!Directory.Exists(pasta))
                    Directory.CreateDirectory(pasta);

                string nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(imagem.FileName);
                string caminho = Path.Combine(pasta, nomeArquivo);

                using (var stream = new FileStream(caminho, FileMode.Create))
                {
                    imagem.CopyTo(stream);
                }

                produto.Cod_Imagem = "/img/produtos/" + nomeArquivo;
            }

            produto.Cod_Usuario = 1;

            _repositorio.Cadastrar(produto);

            ViewBag.Mensagem = "Produto cadastrado com sucesso!";
            return View("CadProduto"); // 👈 DEPOIS DO POST, RETORNA A MESMA VIEW
        }
    }
}
