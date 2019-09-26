using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AllMusic_DLL.BO;

namespace AllMusic_DLL.DAO
{
    public class GeneroDAO
    {
        protected SqlConnection conn;
        Conexion conexion = new Conexion();

        public GeneroDAO()
        {
            conn = conexion.ObtenerConexion();
        }

        public int EjecutarSQL(SqlCommand cmd)
        {
            int resultado = 0;
            try
            {
                cmd.Connection.Open();
                resultado = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return resultado;
            }
            catch
            {
                cmd.Connection.Close();
                return resultado;
            }
        }

        public int Insert(GeneroBO obj)
        {
            string insert = "insert into Genero(NombreGenero) values(@NombreGenero)";
            SqlCommand cmd = new SqlCommand(insert, conn);
            cmd.Parameters.Add(new SqlParameter("@NombreGenero", SqlDbType.NVarChar));

            cmd.Parameters["@NombreGenero"].Value = obj.NombreGenero;

            return EjecutarSQL(cmd);
        }

        public int Update(GeneroBO obj)
        {
            string update = "update Genero set NombreGenero = @NombreGenero where idGenero = @idGenero";
            SqlCommand cmd = new SqlCommand(update, conn);
            cmd.Parameters.Add(new SqlParameter("@NombreGenero", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@idGenero", SqlDbType.Int));

            cmd.Parameters["@NombreGenero"].Value = obj.NombreGenero;
            cmd.Parameters["@idGenero"].Value = obj.idGenero;

            return EjecutarSQL(cmd);
        }

        public int Delete(GeneroBO obj)
        {
            string delete = "delete from Genero where idGenero = @idGenero";
            SqlCommand cmd = new SqlCommand(delete, conn);
            cmd.Parameters.Add(new SqlParameter("@idGenero", SqlDbType.Int)).Value = obj.idGenero;

            return EjecutarSQL(cmd);
        }

        public DataTable Select()
        {
            try
            {
                string listar = "select * from Genero";
                SqlDataAdapter dalistado = new SqlDataAdapter(listar, conn);
                DataTable dtlistado = new DataTable();
                dalistado.Fill(dtlistado);
                return dtlistado;
            }
            catch
            {
                DataTable dt = new DataTable();
                return dt;
            }
        }

    }
}
