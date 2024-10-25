namespace UrbanFarmAPI.Models
{
    public class Funcionario
    {
        public int FuncionarioID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; } = DateTime.Now;
        public string Email { get; set; }
        public string Funcao { get; set; }
        public string SenhaHash { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public int NivelAcesso { get; set; }
    }
}
