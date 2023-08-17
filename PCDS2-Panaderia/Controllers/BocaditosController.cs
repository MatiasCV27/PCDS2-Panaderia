using PCDS2_Panaderia.Data;
using PCDS2_Panaderia.Models;   
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

namespace PCDS2_Panaderia.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class BocaditosController : Controller
    {
        BocaditosData _BocaData = new BocaditosData();

        public IActionResult Listar()
        {
            // La vista mostrara una Lista de Personas
            var oLista = _BocaData.ListarBocaditos();
            return View(oLista);
        }
        public IActionResult Guardar()
        {
            // Metodo solo vuelve a la Vista
            return View();
        }
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
        public IActionResult Editar(int idBocaditos)
        {
            var oBoca = _BocaData.ObtenerBocaditos(idBocaditos);
            return View(oBoca);
        }
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
        public IActionResult Eliminar(int idBocaditos)
        {
            var oBoca = _BocaData.ObtenerBocaditos(idBocaditos);
            return View(oBoca);
        }
        [HttpPost]
        public IActionResult Eliminar(BocaditosModel oBoca)
        {
            var respuesta = _BocaData.EliminarBocaditos(oBoca.idBocaditos);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
