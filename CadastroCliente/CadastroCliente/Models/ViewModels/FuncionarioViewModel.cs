using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CadastroCliente.Models.ViewModels
{
    public class FuncionarioViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do funcionário é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome")]
        [StringLength(200, MinimumLength = 4)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF/CNPJ é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "CPF/CNPJ")]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória", AllowEmptyStrings = false)]
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DtNascimento { get; set; }

        [Required(ErrorMessage = "Otelefone é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "RG")]
        public string Rg { get; set; }

        [Display(Name = "Empresa")]
        public int EmpresaID { get; set; }

    }
}