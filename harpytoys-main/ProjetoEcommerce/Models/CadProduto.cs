namespace ProjetoEcommerce.Models
{
    public class CadProduto
    {
        public int ID_Produto { get; set; } 
        public string? Cod_Imagem { get; set; }
        public string? Cod_Barras { get; set; }
        public string? Descricao { get; set; }
        public string? Valor { get; set; }
        public string? Cod_Usuario { get; set; }
        public List<CadProduto>? CadastroProduto { get; set; }
    }
}
