using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroCliente.Models.ViewModels
{
    public class ListarFuncionariosViewmodel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public DateTime DtCadastro { get; set; }
        public DateTime DtNascimento { get; set; }
        public string Telefone { get; set; }
        public string Rg { get; set; }
        public string EmpresaNome { get; set; }

    }
}