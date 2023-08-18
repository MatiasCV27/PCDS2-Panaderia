using PCDS2_Panaderia.Models;
using System.Data.SqlClient;
using System.Data;

namespace PCDS2_Panaderia.Data
{
    public class TortasData
    {
        public List<TortasModel> ListarTortas()
        {
            var oLista = new List<TortasModel>();
            var cn = new Conexion();
            using (var con = new SqlConnection(cn.getCadenaSQL()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarTortas", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new TortasModel()
                        {
                            idTortas = Convert.ToInt32(dr["idTortas"]),
                            marcaB = dr["marcaB"].ToString(),
                            nombreT = dr["nombreT"].ToString(),
                            descripcionT = dr["descripcionT"].ToString(),
                            costoT = Convert.ToDecimal(dr["costoT"]),
                            fechaCreacionT = Convert.ToDateTime(dr["fechaCreacionT"].ToString()),
                            fechaVencimi = Convert.ToDateTime(dr["fechaVencimi"].ToString()),
                            stockT = Convert.ToInt32(dr["stockT"]),
                            imagenT = dr["imagenT"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }
        public TortasModel ObtenerTortas(int idTortas)
        {
            var oTortas = new TortasModel();
            var cn = new Conexion();
            using (var con = new SqlConnection(cn.getCadenaSQL()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerTortas", con);
                cmd.Parameters.AddWithValue("idTortas", idTortas);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oTortas.idTortas = Convert.ToInt32(dr["idTortas"]);
                        oTortas.marcaB = dr["marcaB"].ToString();
                        oTortas.nombreT = dr["nombreT"].ToString();
                        oTortas.descripcionT = dr["descripcionT"].ToString();
                        oTortas.costoT = Convert.ToDecimal(dr["costoT"]);
                        oTortas.fechaCreacionT = Convert.ToDateTime(dr["fechaCreacionT"].ToString());
                        oTortas.fechaVencimi = Convert.ToDateTime(dr["fechaVencimi"].ToString());
                        oTortas.stockT = Convert.ToInt32(dr["stockT"]);
                        oTortas.imagenT = dr["imagenT"].ToString();
                    }
                }
            }
            return oTortas;
        }
        public bool GuardarTortas(TortasModel oTorta)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var con = new SqlConnection(cn.getCadenaSQL()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarTortas", con);
                    cmd.Parameters.AddWithValue("marcaB", oTorta.marcaB);
                    cmd.Parameters.AddWithValue("nombreT", oTorta.nombreT);
                    cmd.Parameters.AddWithValue("descripcionT", oTorta.descripcionT);
                    cmd.Parameters.AddWithValue("costoT", oTorta.costoT);
                    cmd.Parameters.AddWithValue("fechaCreacionT", oTorta.fechaCreacionT);
                    cmd.Parameters.AddWithValue("fechaVencimi", oTorta.fechaVencimi);
                    cmd.Parameters.AddWithValue("stockT", oTorta.stockT);
                    cmd.Parameters.AddWithValue("imagenT", oTorta.imagenT);
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
        public bool EditarTortas(TortasModel oTorta)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var con = new SqlConnection(cn.getCadenaSQL()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarTortas", con);
                    cmd.Parameters.AddWithValue("idTortas", oTorta.idTortas);
                    cmd.Parameters.AddWithValue("marcaB", oTorta.marcaB);
                    cmd.Parameters.AddWithValue("nombreT", oTorta.nombreT);
                    cmd.Parameters.AddWithValue("descripcionT", oTorta.descripcionT);
                    cmd.Parameters.AddWithValue("costoT", oTorta.costoT);
                    cmd.Parameters.AddWithValue("fechaCreacionT", oTorta.fechaCreacionT);
                    cmd.Parameters.AddWithValue("fechaVencimi", oTorta.fechaVencimi);
                    cmd.Parameters.AddWithValue("stockT", oTorta.stockT);
                    cmd.Parameters.AddWithValue("imagenT", oTorta.imagenT);
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
        public bool EliminarTortas(int idTortas)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var con = new SqlConnection(cn.getCadenaSQL()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarTortas", con);
                    cmd.Parameters.AddWithValue("idTortas", idTortas);
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
