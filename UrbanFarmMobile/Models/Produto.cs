using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanFarmMobile.Models
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string NomeProduto { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public int FornecedorID { get; set; }  // Chave estrangeira para associar um fornecedor
        public DateTime DataCadastro { get; set; }






    }
}
