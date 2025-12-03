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
    }
}
