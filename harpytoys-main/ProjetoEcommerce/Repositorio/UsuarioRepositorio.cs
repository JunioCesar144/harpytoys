using Dapper;
using MySql.Data.MySqlClient;
using ProjetoEcommerce.Models;

namespace ProjetoEcommerce.Repositorio
{
    public class UsuarioRepositorio
    {
        private readonly string _connectionString;

        public UsuarioRepositorio(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("conexaoMySQL");

        }

        private MySqlConnection Conn()
        {
            return new MySqlConnection(_connectionString);
        }

        public Usuario Login(string email, string senha)
        {
            using (var db = Conn())
            {
                string sql = "SELECT * FROM Usuario WHERE Email = @Email AND Senha = @Senha";
                return db.QueryFirstOrDefault<Usuario>(sql, new { Email = email, Senha = senha });
            }
        }
    }
}
