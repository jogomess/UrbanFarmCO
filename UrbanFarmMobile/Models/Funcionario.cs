using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanFarmMobile.Models
{
    public class Funcionario
    {
        public int FuncionarioID { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required]
        [RegularExpression(@"\d{11}", ErrorMessage = "CPF deve ter 11 dígitos")]
        public string CPF { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Funcao { get; set; }
        public DateTime DataCadastro { get; set; }
        public int NivelAcesso { get; set; }
    }
}
