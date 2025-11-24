using System.Web.Mvc;

namespace ProyectoGrupo4.Filters
{
    public class PracticaFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
                return;

            var exception = filterContext.Exception;

            if (exception is Common.PracticaException)
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Error/General.cshtml",
                    ViewData = new ViewDataDictionary
                    {
                        { "MensajeError", exception.Message }
                    }
                };

                filterContext.ExceptionHandled = true;
                return;
            }

            filterContext.Result = new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary
                {
                    { "controller", "Error" },
                    { "action", "ErrorServidor" }
                }
            );

            filterContext.ExceptionHandled = true;
        }
    }
}