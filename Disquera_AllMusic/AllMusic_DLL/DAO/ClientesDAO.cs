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
    public class ClientesDAO
    {
        protected SqlConnection conn;
        Conexion conexion = new Conexion();

        public ClientesDAO()
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

        public int Insert(ClientesBO obj)
        {
            string insert = "insert into Clientes(Nombre,Ciudad,CorreoElectronico,Password) values(@Nombre,@Ciudad,@CorreoElectronico,@Password)";
            SqlCommand cmd = new SqlCommand(insert, conn);
            cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@Ciudad", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@CorreoElectronico", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar));

            cmd.Parameters["@Nombre"].Value = obj.Nombre;
            cmd.Parameters["@Ciudad"].Value = obj.Ciudad;
            cmd.Parameters["@CorreoElectronico"].Value = obj.CorreoElectronico;
            cmd.Parameters["@Password"].Value = obj.Password;
            return EjecutarSQL(cmd);
        }

        public int Update(ClientesBO obj)
        {
            string update = "update Clientes set Nombre = @Nombre, Ciudad = @Ciudad, CorreoElectronico = @CorreoElectronico, Password = @Password where idCliente = @idCliente";
            SqlCommand cmd = new SqlCommand(update, conn);
            cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@Ciudad", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@CorreoElectronico", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@idCliente", SqlDbType.Int));

            cmd.Parameters["@Nombre"].Value = obj.Nombre;
            cmd.Parameters["@Ciudad"].Value = obj.Ciudad;
            cmd.Parameters["@CorreoElectronico"].Value = obj.CorreoElectronico;
            cmd.Parameters["@Password"].Value = obj.Password;
            cmd.Parameters["@idCliente"].Value = obj.idCliente;
            return EjecutarSQL(cmd);
        }

        public int Delete(ClientesBO obj)
        {
            string delete = "delete from Clientes where idCliente = @idCliente";
            SqlCommand cmd = new SqlCommand(delete, conn);
            cmd.Parameters.Add(new SqlParameter("@idCliente", SqlDbType.Int)).Value = obj.idCliente;

            return EjecutarSQL(cmd);
        }

        public DataTable Select()
        {
            try
            {
                string listado = "select * from Clientes";
                SqlDataAdapter dalistado = new SqlDataAdapter(listado, conn);
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
