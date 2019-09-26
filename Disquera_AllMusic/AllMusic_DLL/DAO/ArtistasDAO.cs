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
    public class ArtistasDAO
    {
        protected SqlConnection conn;
        Conexion conexion = new Conexion();

        public ArtistasDAO()
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

        public int Insert(ArtistasBO obj)
        {
            string insert = "insert into Artista(NombreArtistico, NombreReal) values (@NombreArtistico, @NombreReal)";
            SqlCommand cmd = new SqlCommand(insert, conn);
            cmd.Parameters.Add(new SqlParameter("@NombreArtistico", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@NombreReal", SqlDbType.NVarChar));

            cmd.Parameters["@NombreArtistico"].Value = obj.NombreArtistico;
            cmd.Parameters["@NombreReal"].Value = obj.NombreReal;
            return EjecutarSQL(cmd);
        }

        public int Update(ArtistasBO obj)
        {
            string update = "update Artista set NombreArtistico = @NombreArtistico, NombreReal = @NombreReal where idArtista = @idArtista";
            SqlCommand cmd = new SqlCommand(update, conn);
            cmd.Parameters.Add(new SqlParameter("@NombreArtistico", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@NombreReal", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@idArtista", SqlDbType.Int));

            cmd.Parameters["@NombreArtistico"].Value = obj.NombreArtistico;
            cmd.Parameters["@NombreReal"].Value = obj.NombreReal;
            cmd.Parameters["@idArtista"].Value = obj.idArtista;
            return EjecutarSQL(cmd);
        }

        public int Delete(ArtistasBO obj)
        {
            string delete = "delete from Artista where idArtista = @idArtista";
            SqlCommand cmd = new SqlCommand(delete, conn);
            cmd.Parameters.Add(new SqlParameter("@idArtista", SqlDbType.Int)).Value = obj.idArtista;

            return EjecutarSQL(cmd);
        }

        public DataTable Select()
        {
            try
            {
                string listar = "select * from Artista";
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
