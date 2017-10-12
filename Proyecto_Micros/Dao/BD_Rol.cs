using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using System.Data;
using System.Data.SqlClient;

namespace Dao
{
    public class BD_Rol : Singleton<BD_Rol>, IDao<Rol>
    {
        public void Agregar(Rol dato)
        {
            try
            {
                string cmd = "INSERT INTO dbo.Rol (descripcion) VALUES ('" + dato.Descripcion + "')";
                ConexionBaseDatos.EjecutarSql(cmd);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Remover(Rol dato)
        {
            try
            {
                string cmd = "delete from dbo.Rol where(id_rol=" + dato.Id + ")";
                ConexionBaseDatos.EjecutarSql(cmd);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Modificar(Rol dato)
        {
            try
            {
                string cmd = "UPDATE dbo.Rol SET descripcion = ('" + dato.Descripcion + "') WHERE id_rol=" + dato.Id + "";
                ConexionBaseDatos.EjecutarSql(cmd);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<Rol> TraerTodos()
        {
            try
            {
                List<Rol> listaRolesAux = new List<Rol>();
                string cmd = "select * from dbo.Rol";
                DataTable dtNiveles = ConexionBaseDatos.CargarDatos(cmd);
                foreach (DataRow aux in dtNiveles.Rows)
                {
                    Rol Ro = new Rol(Convert.ToInt32(aux["id_rol"]), aux["descripcion"].ToString());
                    listaRolesAux.Add(Ro);
                }
                return listaRolesAux;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int ObtenerID()
        {
            throw new NotImplementedException();
        }

        public Rol buscarPorId(int i)
        {
            string cmdText = "SELECT id_rol, descripcion FROM dbo.Rol WHERE id_rol = " + Convert.ToString(i);
            try
            {
                DataTable dtRoles = ConexionBaseDatos.CargarDatos(cmdText);
                foreach (DataRow aux in dtRoles.Rows)
                {
                    Rol ro = new Rol(Convert.ToInt32(aux["id_rol"]), aux["descripcion"].ToString());
                    return ro;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se encontro el usuario con id " + Convert.ToString(i), ex);
            }
            return null;
        }
    }
}
