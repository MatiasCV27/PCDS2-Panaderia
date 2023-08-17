using Microsoft.AspNetCore.Mvc;
using PCDS2_Panaderia.Data;
using PCDS2_Panaderia.Models;

using Microsoft.AspNetCore.Authorization;

namespace PCDS2_Panaderia.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class TortasController : Controller
    {
        TortasData _TorData = new TortasData();

        public IActionResult Listar()
        {
            // La vista mostrara una Lista de Personas
            var oLista = _TorData.ListarTortas();
            return View(oLista);
        }
        public IActionResult Guardar()
        {
            // Metodo solo vuelve a la Vista
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(TortasModel oTor)
        {
            // Metodo recibe el objeto para guardarlo en BD
            if (!ModelState.IsValid)
                return View();

            var respuesta = _TorData.GuardarTortas(oTor);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        public IActionResult Editar(int idTortas)
        {
            var oTorta = _TorData.ObtenerTortas(idTortas);
            return View(oTorta);
        }
        [HttpPost]
        public IActionResult Editar(TortasModel oTorta)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _TorData.EditarTortas(oTorta);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        public IActionResult Eliminar(int idTortas)
        {
            var oTorta = _TorData.ObtenerTortas(idTortas);
            return View(oTorta);
        }
        [HttpPost]
        public IActionResult Eliminar(TortasModel oTorta)
        {
            var respuesta = _TorData.EliminarTortas(oTorta.idTortas);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
