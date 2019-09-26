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
    public class DiscosDAO
    {
        protected SqlConnection conn;
        Conexion conexion = new Conexion();

        public DiscosDAO()
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

        public int Insert(DiscosBO obj)
        {
            string insert = "insert into Discos(Nombre,Anio,TotalPistas,Precio,Foto,idGenero,idDisquera,idArtista) values(@Nombre,@Anio,@TotalPistas,@Precio,@Foto,@idGenero,@idDisquera,@idArtista)";
            SqlCommand cmd = new SqlCommand(insert, conn);
            cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@Anio", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@TotalPistas", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@Precio", SqlDbType.Decimal));
            cmd.Parameters.Add(new SqlParameter("@Foto", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@idGenero", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@idDisquera", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@idArtista", SqlDbType.Int));

            cmd.Parameters["@Nombre"].Value = obj.Nombre;
            cmd.Parameters["@Anio"].Value = obj.Anio;
            cmd.Parameters["@TotalPistas"].Value = obj.TotalPistas;
            cmd.Parameters["@Precio"].Value = obj.Precio;
            cmd.Parameters["@Foto"].Value = obj.Foto;
            cmd.Parameters["@idGenero"].Value = obj.idGenero;
            cmd.Parameters["@idDisquera"].Value = obj.idDisquera;
            cmd.Parameters["@idArtista"].Value = obj.idArtista;
            return EjecutarSQL(cmd);
        }

        public int Update(DiscosBO obj)
        {
            string update = "update Discos set Nombre = @Nombre, Anio = @Anio, TotalPistas = @TotalPistas, Precio = @Precio, Foto = @Foto, idGenero = @idGenero, idDisquera = @idDisquera, idArtista = @idArtista where idDisco = @idDisco";
            SqlCommand cmd = new SqlCommand(update, conn);
            cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@Anio", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@TotalPistas", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@Precio", SqlDbType.Decimal));
            cmd.Parameters.Add(new SqlParameter("@Foto", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@idGenero", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@idDisquera", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@idArtista", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@idDisco", SqlDbType.Int));

            cmd.Parameters["@Nombre"].Value = obj.Nombre;
            cmd.Parameters["@Anio"].Value = obj.Anio;
            cmd.Parameters["@TotalPistas"].Value = obj.TotalPistas;
            cmd.Parameters["@Precio"].Value = obj.Precio;
            cmd.Parameters["@Foto"].Value = obj.Foto;
            cmd.Parameters["@idGenero"].Value = obj.idGenero;
            cmd.Parameters["@idDisquera"].Value = obj.idDisquera;
            cmd.Parameters["@idArtista"].Value = obj.idArtista;
            cmd.Parameters["@idDisco"].Value = obj.idDisco;
            return EjecutarSQL(cmd);
        }

        public int Delete(DiscosBO obj)
        {
            string delete = "delete from Discos where idDisco = @idDisco";
            SqlCommand cmd = new SqlCommand(delete, conn);
            cmd.Parameters.Add(new SqlParameter("@idDisco", SqlDbType.Int)).Value = obj.idDisco;

            return EjecutarSQL(cmd);
        }

        public DataTable Select()
        {
            try
            {
                string listado = "select * from Discos";
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
