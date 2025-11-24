using System.Web.Mvc;

namespace ProyectoGrupo4.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult General()
        {
            return View();
        }

        public ActionResult NoEncontrada()
        {
            Response.StatusCode = 404;
            return View();
        }

        public ActionResult ErrorServidor()
        {
            Response.StatusCode = 500;
            return View();
        }
    }
}
