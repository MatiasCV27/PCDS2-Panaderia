using Microsoft.AspNetCore.Mvc;
using PCDS2_Panaderia.Data;
using PCDS2_Panaderia.Models;

using Microsoft.AspNetCore.Authorization;

namespace PCDS2_Panaderia.Controllers
{
    public class PanesController : Controller
    {
        PanesData _PanData = new PanesData();

        [Authorize(Roles = "ADMIN")]
        public IActionResult Listar()
        {
            // La vista mostrara una Lista de Personas
            var oLista = _PanData.ListarPanes();
            return View(oLista);
        }
        [Authorize(Roles = "ADMIN")]
        public IActionResult Guardar()
        {
            // Metodo solo vuelve a la Vista
            return View();
        }
        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public IActionResult Guardar(PanesModel oPan)
        {
            // Metodo recibe el objeto para guardarlo en BD
            if (!ModelState.IsValid)
                return View();

            var respuesta = _PanData.GuardarPanes(oPan);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        [Authorize(Roles = "ADMIN")]
        public IActionResult Editar(int idPanes)
        {
            var oPersona = _PanData.ObtenerPanes(idPanes);
            return View(oPersona);
        }
        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public IActionResult Editar(PanesModel oPan)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _PanData.EditarPanes(oPan);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        [Authorize(Roles = "ADMIN")]
        public IActionResult Eliminar(int idPanes)
        {
            var oPan = _PanData.ObtenerPanes(idPanes);
            return View(oPan);
        }
        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public IActionResult Eliminar(PanesModel oPan)
        {
            var respuesta = _PanData.EliminarPanes(oPan.idPanes);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        // User Vista:
        public IActionResult Ver_Panes()
        {
            var oLista = _PanData.ListarPanes();
            return View(oLista);
        }

        // Actualizar Stock
    }
}
