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
    public class UsuariosDAO
    {
        protected SqlConnection conn;
        Conexion conexion = new Conexion();

        public UsuariosDAO()
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

        public int Insert(UsuariosBO obj)
        {
            string insert = "insert into Usuarios(Nombre, Usuario, Password) values(@Nombre, @Usuario, @Password)";
            SqlCommand cmd = new SqlCommand(insert, conn);
            cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar));

            cmd.Parameters["@Nombre"].Value = obj.Nombre;
            cmd.Parameters["@Usuario"].Value = obj.Usuario;
            cmd.Parameters["@Password"].Value = obj.Password;
            return EjecutarSQL(cmd);
        }

        public int Update(UsuariosBO obj)
        {
            string update = "update Usuarios set Nombre = @Nombre, Usuario = @Usuario, Password = @Password where idUsuario = @idUsuario";
            SqlCommand cmd = new SqlCommand(update, conn);
            cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int));

            cmd.Parameters["@Nombre"].Value = obj.Nombre;
            cmd.Parameters["@Usuario"].Value = obj.Usuario;
            cmd.Parameters["@Password"].Value = obj.Password;
            cmd.Parameters["@idUsuario"].Value = obj.idUsuario;
            return EjecutarSQL(cmd);
        }

        public int Delete(UsuariosBO obj)
        {
            string delete = "delete from Usuarios where idUsuario = @idUsuario";
            SqlCommand cmd = new SqlCommand(delete, conn);
            cmd.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int)).Value = obj.idUsuario;

            return EjecutarSQL(cmd);
        }

        public DataTable Select()
        {
            try
            {
                string listado = "select * from Usuarios";
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
