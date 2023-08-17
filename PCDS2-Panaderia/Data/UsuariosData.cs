using PCDS2_Panaderia.Models;

namespace PCDS2_Panaderia.Data
{
    public class UsuariosData
    {
        public List<UsuariosModel> ListaUsuarios()
        {
            return new List<UsuariosModel>
            {
                new UsuariosModel{ usuario = "matias", correo = "admin@gmail.com", clave = "123", rol = new string[] {"ADMIN"} },
                new UsuariosModel{ usuario = "admin", correo = "admin@gmail.com", clave = "123", rol = new string[] {"ADMIN"} },
                new UsuariosModel{ usuario = "user", correo = "user@gmail.com", clave = "123", rol = new string[] {"USER"} }
            };
        }

        public UsuariosModel ValidarUsuario(string _usuario, string _clave)
        {
            return ListaUsuarios().Where(item => item.usuario == _usuario && item.clave == _clave).FirstOrDefault();
        }
    }
}
