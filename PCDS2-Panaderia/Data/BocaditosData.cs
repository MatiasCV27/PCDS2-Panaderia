using PCDS2_Panaderia.Models;
using System.Data.SqlClient;
using System.Data;

namespace PCDS2_Panaderia.Data
{
    public class BocaditosData
    {
        public List<BocaditosModel> ListarBocaditos()
        {
            var oLista = new List<BocaditosModel>();
            var cn = new Conexion();
            using (var con = new SqlConnection(cn.getCadenaSQL()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarBocaditos", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new BocaditosModel()
                        {
                            idBocaditos = Convert.ToInt32(dr["idBocaditos"]),
                            idMarca = Convert.ToInt32(dr["idMarca"]),
                            nombreB = dr["nombreB"].ToString(),
                            descripcionB = dr["descripcionB"].ToString(),
                            costoB = Convert.ToDecimal(dr["costoB"]),
                            fechaCreacionB = Convert.ToDateTime(dr["fechaCreacionB"].ToString()),
                            fechaVencimiB = Convert.ToDateTime(dr["fechaVencimiB"].ToString()),
                        });
                    }
                }
            }
            return oLista;
        }
        public BocaditosModel ObtenerBocaditos(int idBocaditos)
        {
            var oBocados = new BocaditosModel();
            var cn = new Conexion();
            using (var con = new SqlConnection(cn.getCadenaSQL()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerBocaditos", con);
                cmd.Parameters.AddWithValue("idBocaditos", idBocaditos);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oBocados.idBocaditos = Convert.ToInt32(dr["idBocaditos"]);
                        oBocados.idMarca = Convert.ToInt32(dr["idMarca"]);
                        oBocados.nombreB = dr["nombreB"].ToString();
                        oBocados.descripcionB = dr["descripcionB"].ToString();
                        oBocados.costoB = Convert.ToDecimal(dr["costoB"]);
                        oBocados.fechaCreacionB = Convert.ToDateTime(dr["fechaCreacionB"].ToString());
                        oBocados.fechaVencimiB = Convert.ToDateTime(dr["fechaVencimiB"].ToString());
                    }
                }
            }
            return oBocados;
        }
        public bool GuardarBocaditos(BocaditosModel oBoca)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var con = new SqlConnection(cn.getCadenaSQL()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarBocaditos", con);
                    cmd.Parameters.AddWithValue("idMarca", oBoca.idMarca);
                    cmd.Parameters.AddWithValue("nombreB", oBoca.nombreB);
                    cmd.Parameters.AddWithValue("descripcionB", oBoca.descripcionB);
                    cmd.Parameters.AddWithValue("costoB", oBoca.costoB);
                    cmd.Parameters.AddWithValue("fechaCreacionB", oBoca.fechaCreacionB);
                    cmd.Parameters.AddWithValue("fechaVencimiB", oBoca.fechaVencimiB);
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
        public bool EditarBocaditos(BocaditosModel oBoca)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var con = new SqlConnection(cn.getCadenaSQL()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarBocaditos", con);
                    cmd.Parameters.AddWithValue("idBocaditos", oBoca.idBocaditos);
                    cmd.Parameters.AddWithValue("idMarca", oBoca.idMarca);
                    cmd.Parameters.AddWithValue("nombreB", oBoca.nombreB);
                    cmd.Parameters.AddWithValue("descripcionB", oBoca.descripcionB);
                    cmd.Parameters.AddWithValue("costoB", oBoca.costoB);
                    cmd.Parameters.AddWithValue("fechaCreacionB", oBoca.fechaCreacionB);
                    cmd.Parameters.AddWithValue("fechaVencimiB", oBoca.fechaVencimiB);
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
        public bool EliminarBocaditos(int idBocaditos)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var con = new SqlConnection(cn.getCadenaSQL()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarBocaditos", con);
                    cmd.Parameters.AddWithValue("idBocaditos", idBocaditos);
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
    }
}
