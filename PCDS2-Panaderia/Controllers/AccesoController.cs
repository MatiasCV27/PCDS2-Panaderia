using Microsoft.AspNetCore.Mvc;
using PCDS2_Panaderia.Models;
using PCDS2_Panaderia.Data;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace PCDS2_Panaderia.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ValidarUser(UsuariosModel _usuario)
        {
            UsuariosData _usuarioData = new UsuariosData();
            var usuario = _usuarioData.ValidarUsuario(_usuario.usuario, _usuario.clave);
            if (usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.usuario),
                    new Claim(ClaimTypes.Role, usuario.rol),
                    new Claim("Correo", usuario.correo)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            } else
            {
                return View();
            }
        }
        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Acceso");
        }

        // CRUD
        //UsuariosData _userData = new UsuariosData();
        //public IActionResult ListarUser()
        //{
        //    // La vista mostrara una Lista de Personas
        //    var oLista = _userData.ListaUsuarios();
        //    return View(oLista);
        //}
        //public IActionResult Guardar()
        //{
        //    // Metodo solo vuelve a la Vista
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Guardar(UsuariosModel oUser)
        //{
        //    // Metodo recibe el objeto para guardarlo en BD
        //    if (!ModelState.IsValid)
        //        return View();

        //    var respuesta = _userData.GuardarUsuarios(oUser);

        //    if (respuesta)
        //        return RedirectToAction("ListarUser");
        //    else
        //        return View();
        //}
        //public IActionResult Editar(int idUser)
        //{
        //    var oUser = _userData.ObtenerUsuarios(idUser);
        //    return View(oUser);
        //}
        //[HttpPost]
        //public IActionResult Editar(UsuariosModel oUser)
        //{
        //    if (!ModelState.IsValid)
        //        return View();

        //    var respuesta = _userData.EditarUsuarios(oUser);

        //    if (respuesta)
        //        return RedirectToAction("ListarUser");
        //    else
        //        return View();
        //}
        //public IActionResult Eliminar(int idUser)
        //{
        //    var oUser = _userData.ObtenerUsuarios(idUser);
        //    return View(oUser);
        //}
        //[HttpPost]
        //public IActionResult Eliminar(UsuariosModel oUser)
        //{
        //    var respuesta = _userData.EliminarUsuarios(oUser.idUsuario);

        //    if (respuesta)
        //        return RedirectToAction("ListarUser");
        //    else
        //        return View();
        //}
    }
}
