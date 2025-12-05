namespace ProjetoEcommerce.Models
{
    public class Produto
    {
        public int ID_Produto { get; set; }
        public string Cod_Imagem { get; set; }
        public string Cod_Barras { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int Cod_Usuario { get; set; }
    }
}
