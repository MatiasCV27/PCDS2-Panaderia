using PCDS2_Panaderia.Data;
using PCDS2_Panaderia.Models;   
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

namespace PCDS2_Panaderia.Controllers
{
    public class BocaditosController : Controller
    {
        BocaditosData _BocaData = new BocaditosData();

        [Authorize(Roles = "ADMIN")]
        public IActionResult Listar()
        {
            // La vista mostrara una Lista de Personas
            var oLista = _BocaData.ListarBocaditos();
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
        public IActionResult Guardar(BocaditosModel oBoca)
        {
            // Metodo recibe el objeto para guardarlo en BD
            if (!ModelState.IsValid)
                return View();

            var respuesta = _BocaData.GuardarBocaditos(oBoca);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        [Authorize(Roles = "ADMIN")]
        public IActionResult Editar(int idBocaditos)
        {
            var oBoca = _BocaData.ObtenerBocaditos(idBocaditos);
            return View(oBoca);
        }
        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public IActionResult Editar(BocaditosModel oBoca)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _BocaData.EditarBocaditos(oBoca);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        [Authorize(Roles = "ADMIN")]
        public IActionResult Eliminar(int idBocaditos)
        {
            var oBoca = _BocaData.ObtenerBocaditos(idBocaditos);
            return View(oBoca);
        }
        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public IActionResult Eliminar(BocaditosModel oBoca)
        {
            var respuesta = _BocaData.EliminarBocaditos(oBoca.idBocaditos);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        // User Vista:
        public IActionResult Ver_Bocaditos()
        {
            // La vista mostrara una Lista de Personas
            var oLista = _BocaData.ListarBocaditos();
            return View(oLista);
        }
    }
}
