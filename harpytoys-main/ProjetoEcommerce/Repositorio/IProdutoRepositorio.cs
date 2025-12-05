using Dapper;
using MySql.Data.MySqlClient;
using ProjetoEcommerce.Models;

namespace ProjetoEcommerce.Repositorio
{
    public class ProdutoRepositorio
    {
        private readonly string _connectionString;

        public ProdutoRepositorio(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("conexaoMySQL");
        }

        private MySqlConnection Conn()
        {
            return new MySqlConnection(_connectionString);
        }

        public List<Produto> ObterTodos()
        {
            using (var db = Conn())
            {
                string sql = @"SELECT 
                                ID_Produto,
                                Cod_Imagem,
                                Cod_Barras,
                                Descricao,
                                Valor,
                                Cod_Usuario
                               FROM Produto
                               ORDER BY Descricao ASC";

                return db.Query<Produto>(sql).ToList();
            }
        }

        public Produto ObterPorId(int id)
        {
            using (var db = Conn())
            {
                string sql = @"SELECT 
                                ID_Produto,
                                Cod_Imagem,
                                Cod_Barras,
                                Descricao,
                                Valor,
                                Cod_Usuario
                               FROM Produto
                               WHERE ID_Produto = @id";

                return db.QueryFirstOrDefault<Produto>(sql, new { id });
            }
        }

        public void Cadastrar(Produto p)
        {
            using (var db = Conn())
            {
                string sql = @"
                    INSERT INTO Produto 
                    (ID_Produto, Cod_Imagem, Cod_Barras, Descricao, Valor, Cod_Usuario)
                    VALUES (@ID_Produto, @Cod_Imagem, @Cod_Barras, @Descricao, @Valor, @Cod_Usuario)
                ";

                db.Execute(sql, p);
            }
        }

        public void Atualizar(Produto p)
        {
            using (var db = Conn())
            {
                string sql = @"
                    UPDATE Produto SET
                        Cod_Imagem = @Cod_Imagem,
                        Cod_Barras = @Cod_Barras,
                        Descricao = @Descricao,
                        Valor = @Valor,
                        Cod_Usuario = @Cod_Usuario
                    WHERE ID_Produto = @ID_Produto
                ";

                db.Execute(sql, p);
            }
        }

        public void Deletar(int id)
        {
            using (var db = Conn())
            {
                string sql = @"DELETE FROM Produto WHERE ID_Produto = @id";
                db.Execute(sql, new { id });
            }
        }
    }
}
