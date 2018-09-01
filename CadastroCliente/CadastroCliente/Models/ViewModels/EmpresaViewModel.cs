using CadastroCliente.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace CadastroCliente.Models.ViewModels
{
    public class EmpresaViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public EnUf UF { get; set; }

        [Required(ErrorMessage = "O nome do fantasia da empresa é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome Fantasia")]
        [StringLength(200, MinimumLength = 4)]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; }
    }
}