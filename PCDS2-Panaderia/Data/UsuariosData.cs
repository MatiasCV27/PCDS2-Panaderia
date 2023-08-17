using PCDS2_Panaderia.Models;
using System.Data.SqlClient;
using System.Data;


namespace PCDS2_Panaderia.Data
{
    public class UsuariosData
    {
        public List<UsuariosModel> ListaUsuarios()
        {
            var oLista = new List<UsuariosModel>();
            var cn = new Conexion();
            using (var con = new SqlConnection(cn.getCadenaSQL()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarUsuarios", con);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new UsuariosModel()
                        {
                            idUsuario = Convert.ToInt32(dr["idUsuario"]),
                            usuario = dr["usuario"].ToString(),
                            correo = dr["correo"].ToString(),
                            clave = dr["clave"].ToString(),
                            rol = dr["rol"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }
        public UsuariosModel ObtenerUsuarios(int idUser)
        {
            var oUser = new UsuariosModel();
            var cn = new Conexion();
            using (var con = new SqlConnection(cn.getCadenaSQL()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerUsuarios", con);
                cmd.Parameters.AddWithValue("idUsuario", idUser);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oUser.idUsuario = Convert.ToInt32(dr["idUsuario"]);
                        oUser.usuario = dr["usuario"].ToString();
                        oUser.correo = dr["correo"].ToString();
                        oUser.clave = dr["clave"].ToString();
                        oUser.rol = dr["rol"].ToString();
                    }
                }
            }
            return oUser;
        }
        public bool GuardarUsuarios(UsuariosModel oUser)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var con = new SqlConnection(cn.getCadenaSQL()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarUsuarios", con);
                    cmd.Parameters.AddWithValue("usuario", oUser.usuario);
                    cmd.Parameters.AddWithValue("correo", oUser.correo);
                    cmd.Parameters.AddWithValue("clave", oUser.clave);
                    cmd.Parameters.AddWithValue("rol", oUser.rol);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }
        public bool EditarUsuarios(UsuariosModel oUser)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var con = new SqlConnection(cn.getCadenaSQL()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarUsuarios", con);
                    cmd.Parameters.AddWithValue("idUsuario", oUser.idUsuario);
                    cmd.Parameters.AddWithValue("usuario", oUser.usuario);
                    cmd.Parameters.AddWithValue("correo", oUser.correo);
                    cmd.Parameters.AddWithValue("clave", oUser.clave);
                    cmd.Parameters.AddWithValue("rol", oUser.rol);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }
        public bool EliminarUsuarios(int idUser)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var con = new SqlConnection(cn.getCadenaSQL()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarUsuarios", con);
                    cmd.Parameters.AddWithValue("idUsuario", idUser);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }
        public UsuariosModel ValidarUsuario(string _usuario, string _clave)
        {
            return ListaUsuarios().Where(item => item.usuario == _usuario && item.clave == _clave).FirstOrDefault();
        }
    }
}
