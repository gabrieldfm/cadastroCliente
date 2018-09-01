using CadastroCliente.Models;
using CadastroCliente.Models.ViewModels;
using System;
using System.Web.Mvc;
using CadastroCliente.Utils;

namespace CadastroCliente.Controllers
{
    public class EmpresaController:Controller
    {
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(EmpresaViewModel empresa)
        {
            if (StringFormatUtil.SemFormatacao(empresa.CNPJ).Length < 14)
            {
                ModelState.AddModelError("empresa.Invalida", "CNPJ inválido!");
            }
            if (ModelState.IsValid)
            {

                var novaEmpresa = new Empresa
                {
                    NomeFantasia = empresa.NomeFantasia,
                    CNPJ = StringFormatUtil.SemFormatacao(empresa.CNPJ),
                    UF = empresa.UF.GetDescription(),
                };

                using (var contexto = new ApplicationContext())
                {
                    contexto.Empresas.Add(novaEmpresa);
                    contexto.SaveChanges();
                }


                TempData["success"] = "Empresa cadastrada com sucesso!";

                return RedirectToAction("Index", "Home");
                
            }

            TempData["warning"] = "Não foi possível cadastrar a empresa!";
            return View(empresa);
        }
    }
}