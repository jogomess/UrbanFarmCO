namespace UrbanFarmAPI.Models
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string NomeProduto { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public int FornecedorID { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}
