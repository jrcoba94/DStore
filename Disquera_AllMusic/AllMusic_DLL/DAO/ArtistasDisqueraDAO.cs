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
    public class ArtistasDisqueraDAO
    {
        protected SqlConnection conn;
        Conexion conexion = new Conexion();

        public ArtistasDisqueraDAO()
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

        public int Insert(ArtistasDisqueraBO obj)
        {
            string insert = "insert into ArtistasPorDisquera(idArtista, idDisquera) values(@idArtista,@idDisquera)";
            SqlCommand cmd = new SqlCommand(insert, conn);
            cmd.Parameters.Add(new SqlParameter("@idArtista", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@idDisquera", SqlDbType.Int));

            cmd.Parameters["@idArtista"].Value = obj.idArtista;
            cmd.Parameters["@idDisquera"].Value = obj.idDisquera;
            return EjecutarSQL(cmd);
        }

        public int Update(ArtistasDisqueraBO obj)
        {
            string update = "update ArtistasPorDisquera set idArtista = @idArtista, idDisquera = @idDisquera where idAD = @idArtistaD";
            SqlCommand cmd = new SqlCommand(update, conn);
            cmd.Parameters.Add(new SqlParameter("@idArtista", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@idDisquera", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@idArtistaD", SqlDbType.Int));

            cmd.Parameters["@idArtista"].Value = obj.idArtista;
            cmd.Parameters["@idDisquera"].Value = obj.idDisquera;
            cmd.Parameters["@idArtistaD"].Value = obj.idAD;
            return EjecutarSQL(cmd);
        }

        public int Delete(ArtistasDisqueraBO obj)
        {
            string delete = "delete from ArtistasPorDisquera where idArtistaD = @idArtistaD";
            SqlCommand cmd = new SqlCommand(delete, conn);
            cmd.Parameters.Add(new SqlParameter("@idArtistaD", SqlDbType.Int)).Value = obj.idAD;

            return EjecutarSQL(cmd);
        }

        public DataTable Select()
        {
            try
            {
                string listar = "select * from ArtistasPorDisquera";
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
