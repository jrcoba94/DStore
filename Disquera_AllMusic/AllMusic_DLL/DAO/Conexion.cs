using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AllMusic_DLL.DAO
{
    public class Conexion
    {
        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(@"Data Source=.;Initial Catalog=Disquera;Integrated Security=true");
        }
    }
}
