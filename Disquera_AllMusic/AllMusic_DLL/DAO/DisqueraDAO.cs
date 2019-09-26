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
    public class DisqueraDAO
    {
        protected SqlConnection conn;
        Conexion conexion = new Conexion();

        public DisqueraDAO()
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

        public int Insert(DisqueraBO obj)
        {
            string insert = "insert into Disquera(Nombre) values(@Nombre)";
            SqlCommand cmd = new SqlCommand(insert, conn);
            cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar));

            cmd.Parameters["@Nombre"].Value = obj.Nombre;
            return EjecutarSQL(cmd);
        }

        public int Update(DisqueraBO obj)
        {
            string update = "update Disquera set Nombre = @Nombre where idDisquera = @idDisquera";
            SqlCommand cmd = new SqlCommand(update, conn);
            cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@idDisquera", SqlDbType.Int));

            cmd.Parameters["@Nombre"].Value = obj.Nombre;
            cmd.Parameters["@idDisquera"].Value = obj.idDisquera;
            return EjecutarSQL(cmd);
        }

        public int Delete(DisqueraBO obj)
        {
            string delete = "delete from Disquera where idDisquera = @idDisquera";
            SqlCommand cmd = new SqlCommand(delete, conn);
            cmd.Parameters.Add(new SqlParameter("@idDisquera", SqlDbType.Int)).Value = obj.idDisquera;

            return EjecutarSQL(cmd);
        }

        public DataTable Select()
        {
            try
            {
                string listar = "select * from Disquera";
                SqlDataAdapter dalistar = new SqlDataAdapter(listar, conn);
                DataTable dtlistar = new DataTable();
                dalistar.Fill(dtlistar);
                return dtlistar;
            }
            catch
            {
                DataTable dt = new DataTable();
                return dt;
            }
        }



    }
}
