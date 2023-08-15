using System.Data.SqlClient;

namespace PCDS2_Panaderia.Data
{
    public class Conexion
    {
        private string cadenaSql = string.Empty;

        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSql = builder.GetSection("ConnectionStrings:CadenaSql").Value;
        }

        public string getCadenaSQL()
        {
            return cadenaSql;
        }
    }
}
