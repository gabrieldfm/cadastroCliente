
using System.ComponentModel.DataAnnotations;

namespace CadastroCliente.Models
{
    public class Empresa
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UF { get; set; }
        [Required]
        public string NomeFantasia { get; set; }
        [Required]
        public string CNPJ { get; set; }
    }
}