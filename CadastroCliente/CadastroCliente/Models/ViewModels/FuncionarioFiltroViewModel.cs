using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroCliente.Models.ViewModels
{
    public class FuncionarioFiltroViewModel
    {
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime DtNascimentoDe { get; set; }

        public DateTime DtNascimentoAte { get; set; }

        [Display(Name = "Data de cadastro")]
        public DateTime DtCadastroDe { get; set; }

        public DateTime DtCadastroAte { get; set; }
    }
}