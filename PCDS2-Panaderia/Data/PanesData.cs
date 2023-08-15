using PCDS2_Panaderia.Models;
using System.Data.SqlClient;
using System.Data;

namespace PCDS2_Panaderia.Data
{
    public class PanesData
    {
        public List<PanesModel> ListarPanes()
        {
            var oLista = new List<PanesModel>();
            var cn = new Conexion();
            using (var con = new SqlConnection(cn.getCadenaSQL()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarPanes", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new PanesModel()
                        {
                            idPanes = Convert.ToInt32(dr["idPanes"]),
                            idMarca = Convert.ToInt32(dr["idMarca"]),
                            nombreP = dr["nombreP"].ToString(),
                            descripcionP = dr["descripcionP"].ToString(),
                            costoP = Convert.ToDecimal(dr["costoP"]),
                            fechaCreacionP = Convert.ToDateTime(dr["fechaCreacionP"].ToString()),
                            fechaVencimiP = Convert.ToDateTime(dr["fechaVencimiP"].ToString()),
                        });
                    }
                }
            }
            return oLista;
        }
        public PanesModel ObtenerPanes(int idPanes)
        {
            var oPanes = new PanesModel();
            var cn = new Conexion();
            using (var con = new SqlConnection(cn.getCadenaSQL()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerPanes", con);
                cmd.Parameters.AddWithValue("idPanes", idPanes);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oPanes.idPanes = Convert.ToInt32(dr["idPanes"]);
                        oPanes.idMarca = Convert.ToInt32(dr["idMarca"]);
                        oPanes.nombreP = dr["nombreP"].ToString();
                        oPanes.descripcionP = dr["descripcionP"].ToString();
                        oPanes.costoP = Convert.ToDecimal(dr["costoP"]);
                        oPanes.fechaCreacionP = Convert.ToDateTime(dr["fechaCreacionP"].ToString());
                        oPanes.fechaVencimiP = Convert.ToDateTime(dr["fechaVencimiP"].ToString());
                    }
                }
            }
            return oPanes;
        }
        public bool GuardarPanes(PanesModel oPanes)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var con = new SqlConnection(cn.getCadenaSQL()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarPanes", con);
                    cmd.Parameters.AddWithValue("idMarca", oPanes.idMarca);
                    cmd.Parameters.AddWithValue("nombreP", oPanes.nombreP);
                    cmd.Parameters.AddWithValue("descripcionP", oPanes.descripcionP);
                    cmd.Parameters.AddWithValue("costoP", oPanes.costoP);
                    cmd.Parameters.AddWithValue("fechaCreacionP", oPanes.fechaCreacionP);
                    cmd.Parameters.AddWithValue("fechaVencimiP", oPanes.fechaVencimiP);
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
        public bool EditarPanes(PanesModel oPanes)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var con = new SqlConnection(cn.getCadenaSQL()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarPanes", con);
                    cmd.Parameters.AddWithValue("idPanes", oPanes.idPanes);
                    cmd.Parameters.AddWithValue("idMarca", oPanes.idMarca);
                    cmd.Parameters.AddWithValue("nombreP", oPanes.nombreP);
                    cmd.Parameters.AddWithValue("descripcionP", oPanes.descripcionP);
                    cmd.Parameters.AddWithValue("costoP", oPanes.costoP);
                    cmd.Parameters.AddWithValue("fechaCreacionP", oPanes.fechaCreacionP);
                    cmd.Parameters.AddWithValue("fechaVencimiP", oPanes.fechaVencimiP);
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
        public bool EliminarPanes(int idPanes)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var con = new SqlConnection(cn.getCadenaSQL()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarPanes", con);
                    cmd.Parameters.AddWithValue("idPanes", idPanes);
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
