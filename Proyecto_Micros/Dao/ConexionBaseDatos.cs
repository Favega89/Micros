using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Dao
{
    class ConexionBaseDatos
    {
        static SqlConnection cn = new SqlConnection("Data Source=USUARIO-PC\\SQLEXPRESS;Initial Catalog=Prueba;Integrated Security=True");

        static private void Conectar()
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
            }
            catch
            {
                throw new Exception("Error conexion");
            }
        }

        static void Desconectar()
        {
            try
            {
                cn.Close();
            }
            catch
            {
                throw new Exception("Error de conexion");
            }
        }

        static public int EjecutarEscalar(string cmdText)
        {
            try
            {
                Conectar();
                SqlCommand cmd = new SqlCommand(cmdText, cn);
                int aux = Convert.ToInt32(cmd.ExecuteScalar());
                Desconectar();
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static public DataTable CargarDatos(string cmdText)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand(cmdText, cn);
                Conectar();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static public void EjecutarSql(string cmdText)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(cmdText, cn);
                Conectar();
                cmd.ExecuteNonQuery();
                Desconectar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static public DataTable getData(string cmdText)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand(cmdText, cn))
                {
                    Conectar();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    Desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron cargar los datos (DBCommonAccess)", ex);
            }
            return dt;
        }
    }
}
