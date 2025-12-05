using Dapper;
using MySql.Data.MySqlClient;
using ProjetoEcommerce.Models;

namespace ProjetoEcommerce.Repositorio
{
    public class CadProdutoRepositorio
    {
        private readonly string _connectionString;

        public CadProdutoRepositorio(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("conexaoMySQL");
        }

        private MySqlConnection Conn()
        {
            return new MySqlConnection(_connectionString);
        }

        // ============================
        // CADASTRAR
        // ============================
        public void Cadastrar(CadProduto produto)
        {
            using (var db = Conn())
            {
                string sql = @"
                    INSERT INTO Produto 
                    (ID_Produto, Cod_Imagem, Cod_Barras, Descricao, Valor, Cod_Usuario)
                    VALUES (@ID_Produto, @Cod_Imagem, @Cod_Barras, @Descricao, @Valor, @Cod_Usuario)
                ";

                db.Execute(sql, produto);
            }
        }





        // ============================
        // PESQUISAR POR NOME
        // ============================
        public CadProduto BuscarPorNome(string nome)
        {
            using (var db = Conn())
            {
                string sql = @"
            SELECT * 
            FROM Produto
            WHERE Descricao LIKE CONCAT('%', @Nome, '%')
        ";

                return db.QueryFirstOrDefault<CadProduto>(sql, new { Nome = nome });
            }
        }


        // ============================
        // EXCLUIR PRODUTO
        // ============================
        public bool ExcluirPorNome(string nome)
        {
            using (var db = Conn())
            {
                string sql = @"
            DELETE FROM Produto
            WHERE Descricao LIKE CONCAT('%', @Nome, '%')
        ";

                int linhas = db.Execute(sql, new { Nome = nome });

                return linhas > 0;
            }
        }

    }
}

