using CadastroCliente.Models;
using CadastroCliente.Models.ViewModels;
using CadastroCliente.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Controllers
{
    public class FuncionarioController : Controller
    {
        public ActionResult Cadastrar()
        {
            using (var contexto = new ApplicationContext())
            {
                var empresas = contexto.Empresas.ToList();
                ViewBag.Empresa = new SelectList(
                 empresas,
                 "Id",
                 "NomeFantasia");

                return View();
            }
           
        }

        [HttpPost]
        public ActionResult Cadastrar(FuncionarioViewModel funcionario, int Empresa, int recebeOpcao)
        {

            #region validações
            if (recebeOpcao == 1 )
            {
                if(StringFormatUtil.SemFormatacao(funcionario.CpfCnpj).Length < 11)
                    ModelState.AddModelError("funcionario.CpfInvalido", "CPF inválido!");
                if (string.IsNullOrWhiteSpace(funcionario.Rg))
                    ModelState.AddModelError("funcionario.Rg", "Para pessoa fisíca é necessário o RG");
            }
            if(recebeOpcao == 2 && StringFormatUtil.SemFormatacao(funcionario.CpfCnpj).Length < 14)
                ModelState.AddModelError("funcionario.CnpjInvalido", "CNPJ inválido!");

            if (funcionario.DtNascimento.AddYears(18) > DateTime.Now)
            {
                using (var contexto = new ApplicationContext())
                {
                    var empresa = contexto.Empresas.SingleOrDefault(e => e.Id == Empresa);
                    if (empresa.UF.Equals("PR"))
                        ModelState.AddModelError("funcionario.Menor", "Para empresas do PR não é possível cadastrar um funcionário menor de idade!");
                }
            }
            #endregion

            if (ModelState.IsValid)
            {
                using (var contexto = new ApplicationContext())
                {
                    var novoFunc = new Funcionario
                    {
                        Nome = funcionario.Nome,
                        CpfCnpj = StringFormatUtil.SemFormatacao(funcionario.CpfCnpj),
                        DtCadastro = DateTime.Now,
                        DtNascimento = funcionario.DtNascimento,
                        Telefone = funcionario.Telefone,
                        Rg = funcionario.Rg,
                        Empresa = contexto.Empresas.SingleOrDefault(e => e.Id == Empresa)
                    };
                
                    contexto.Funcionarios.Add(novoFunc);
                    contexto.SaveChanges();
                }

                TempData["success"] = "Funcionário cadastrado com sucesso!";
                
                return RedirectToAction("Index", "Home");
            }

            TempData["warning"] = "Não foi possível cadastrar o funcionário!";
            using (var contexto = new ApplicationContext())
            {
                var empresas = contexto.Empresas.ToList();
                ViewBag.Empresa = new SelectList(
                 empresas,
                 "Id",
                 "NomeFantasia");

                return View(funcionario);
            }

        }

        public ActionResult FiltroFuncionarios()
        {
            return View();
        }

        public ActionResult ListarFuncionarios(FuncionarioFiltroViewModel filtros)
        {

            #region validações
            var valido = true;
            if(filtros.DtNascimentoAte < filtros.DtNascimentoDe && filtros.DtNascimentoDe != DateTime.MinValue)
            {
                ModelState.AddModelError("filtros.DtDeNasc", "Data de nascimento final não pode ser menor que a inicial!");
                valido = false;
            }
            if (filtros.DtCadastroAte < filtros.DtCadastroDe && filtros.DtCadastroDe != DateTime.MinValue)
            {
                ModelState.AddModelError("filtros.DtDeCad", "Data de cadastro final não pode ser menor que a inicial!");
                valido = false;
            }

            #endregion

            if (valido)
            {

                using (var contexto = new ApplicationContext())
                {
                    var funcionarios = new List<ListarFuncionariosViewmodel>();

                    var lista = from f in contexto.Funcionarios.Include(e => e.Empresa) select f;

                    if (!string.IsNullOrWhiteSpace(filtros.Nome))
                    {
                        lista = lista.Where(n => n.Nome.Contains(filtros.Nome));
                    }
                    if(filtros.DtNascimentoDe != DateTime.MinValue)
                    {
                        lista = lista.Where(n => n.DtNascimento > filtros.DtNascimentoDe);
                    }
                    if (filtros.DtNascimentoAte.Year != 1)
                    {
                        lista = lista.Where(n => n.DtNascimento < filtros.DtNascimentoAte);
                    }
                    if (filtros.DtCadastroDe != DateTime.MinValue)
                    {
                        lista = lista.Where(n => n.DtNascimento > filtros.DtCadastroDe);
                    }
                    if (filtros.DtCadastroAte.Year != 1)
                    {
                        lista = lista.Where(n => n.DtNascimento < filtros.DtCadastroAte);
                    }

                    foreach(var linha in lista)
                    {
                        var func = new ListarFuncionariosViewmodel
                        {
                            Id = linha.Id,
                            Nome = linha.Nome,
                            CpfCnpj = linha.CpfCnpj,
                            Telefone = linha.Telefone,
                            DtNascimento = linha.DtNascimento,
                            DtCadastro = linha.DtCadastro,
                            Rg = linha.Rg,
                            EmpresaNome = linha.Empresa.NomeFantasia
                        };

                        funcionarios.Add(func);
                    }

                    return View(funcionarios);
                }

            }

            return View(filtros);
        }

    }
}