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

        // ============================
        //   TELA CADASTRO
        // ============================
        [HttpGet]
        public IActionResult Cadastro()
        {
            return View("CadProduto");
        }

        // ============================
        //   CADASTRAR PRODUTO
        // ============================
        [HttpPost]
        public IActionResult Cadastro(CadProduto produto, IFormFile imagem)
        {
            produto.ID_Produto = new Random().Next(1000, 9999);

            if (imagem != null && imagem.Length > 0)
            {
                string pasta = Path.Combine(_environment.WebRootPath, "img/produtos");

                if (!Directory.Exists(pasta))
                    Directory.CreateDirectory(pasta);

                string nomeArquivo = Guid.NewGuid() + Path.GetExtension(imagem.FileName);
                string caminho = Path.Combine(pasta, nomeArquivo);

                using (var stream = new FileStream(caminho, FileMode.Create))
                    imagem.CopyTo(stream);

                produto.Cod_Imagem = "/img/produtos/" + nomeArquivo;
            }

            produto.Cod_Usuario = 1;

            _repositorio.Cadastrar(produto);

            ViewBag.Mensagem = "Produto cadastrado com sucesso!";
            return View("CadProduto");
        }

        // ============================
        //   PESQUISAR PRODUTO
        // ============================
        [HttpPost]
        public IActionResult Pesquisar(string Descricao)
        {
            var produto = _repositorio.BuscarPorNome(Descricao);

            if (produto == null)
            {
                ViewBag.Mensagem = "Produto não encontrado!";
                return View("CadProduto");
            }

            return View("CadProduto", produto);
        }

        // ============================
        //   EXCLUIR PRODUTO
        // ============================
        [HttpPost]
        public IActionResult Excluir(string Descricao)
        {
            bool excluiu = _repositorio.ExcluirPorNome(Descricao);

            if (!excluiu)
            {
                ViewBag.Mensagem = "Nenhum produto encontrado para excluir!";
                return View("CadProduto");
            }

            ViewBag.Mensagem = "Produto excluído com sucesso!";
            return View("CadProduto");
        }
    }
}
