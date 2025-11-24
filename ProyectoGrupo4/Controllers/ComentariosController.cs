using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ProyectoGrupo4.Common;
using ProyectoGrupo4.Models;

namespace ProyectoGrupo4.Controllers
{
    [Authorize]
    public class ComentariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comentarios
        public ActionResult Index()
        {
            try
            {
                var comentarios = db.Comentarios.Include(c => c.User)
                                                .OrderByDescending(c => c.FechaCreacion)
                                                .ToList();

                // Enviar datos requeridos por la práctica
                ViewBag.Usuario = User.Identity.GetUserName();
                ViewBag.TotalComentarios = comentarios.Count;

                if (TempData["Mensaje"] != null)
                    ViewBag.Mensaje = TempData["Mensaje"];

                return View(comentarios);
            }
            catch (Exception ex)
            {
                throw new PracticaException("Ocurrio un error al cargar los comentarios. ");
            }
        }

        // GET: Comentarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comentarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comentario comentario)
        {
            try {
                if (ModelState.IsValid)
                {
                    comentario.UserId = User.Identity.GetUserId();
                    comentario.FechaCreacion = DateTime.Now;

                    db.Comentarios.Add(comentario);
                    db.SaveChanges();

                    TempData["Mensaje"] = "Comentario publicado correctamente.";
                    return RedirectToAction("Index");
                }

                return View(comentario);
            }
            catch (Exception ex)
            {
                throw new PracticaException("No se pudo crear el comentario. Intente nuevamente.");
            }
            }

    }
}
