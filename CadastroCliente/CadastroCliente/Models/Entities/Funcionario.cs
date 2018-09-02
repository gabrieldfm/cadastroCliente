using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroCliente.Models
{
    public class Funcionario
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string CpfCnpj { get; set; }
        [Required]
        public DateTime DtCadastro { get; set; }
        [Required]
        public DateTime DtNascimento { get; set; }
        [Required]
        public string Telefone { get; set; }
        public string Rg { get; set; }

        [Required]
        public Empresa Empresa { get; set; }


    }
}