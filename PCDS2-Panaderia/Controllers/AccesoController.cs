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

                return RedirectToAction("Ver_Panes", "Panes");
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
    }
}
