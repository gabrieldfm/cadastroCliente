using System.Web.Mvc;

namespace CadastroCliente.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}