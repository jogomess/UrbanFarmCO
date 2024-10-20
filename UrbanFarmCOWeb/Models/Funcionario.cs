namespace UrbanFarmCOWeb.Models
{
    public class Funcionario
    {
        public int FuncionarioID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Funcao { get; set; }
        public string SenhaHash { get; set; }
        public DateTime DataCadastro { get; set; }






    }
}
