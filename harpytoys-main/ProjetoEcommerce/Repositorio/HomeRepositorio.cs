using ProjetoEcommerce.Models;

namespace ProjetoEcommerce.Repositorio
{
    public class HomeRepositorio
    {
        // Responsável por buscar dados (podem vir do banco futuramente)
        public HomeModel ObterDadosHome()
        {
            HomeModel model = new HomeModel();

            // Exemplos de eventos do sistema
            model.EventosSistema.Add("Sistema iniciado.");
            model.EventosSistema.Add("Usuário logado com sucesso.");
            model.EventosSistema.Add("Bem-vindo ao sistema HarpyToys!");

            return model;
        }
    }
}
