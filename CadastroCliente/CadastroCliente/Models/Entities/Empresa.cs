
using CadastroCliente.Models.Enum;
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

        //[Required]
        //public int Id { get; set; }

        //[Required]
        //public EnUf UF { get; set; }

        //[Required(ErrorMessage = "O nome do fantasia da empresa é obrigatório", AllowEmptyStrings = false)]
        //[Display(Name = "Nome Fantasia")]
        //[StringLength(200, MinimumLength = 4)]
        //public string NomeFantasia { get; set; }

        //[Required(ErrorMessage = "O CNPJ é obrigatório", AllowEmptyStrings = false)]
        //[Display(Name = "CNPJ")]
        //public string CNPJ { get; set; }
    }
}