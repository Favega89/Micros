using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using System.Data;
using System.Data.SqlClient;

namespace Dao
{
    public class BD_TransporteUrbano : Singleton<BD_TransporteUrbano>, IDao<TransporteUrbano>
    {
        public void Agregar(TransporteUrbano dato)
        {
            try
            {
                string cmd = "INSERT INTO dbo.TransporteUrbano (descripcion,linea) VALUES ('" + dato.Descripcion + "','" + dato.Linea + "')";
                ConexionBaseDatos.EjecutarSql(cmd);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Remover(TransporteUrbano dato)
        {
            try
            {
                string cmd = "delete from dbo.TransporteUrbano where(id_transporteurb=" + dato.Id + ")";
                ConexionBaseDatos.EjecutarSql(cmd);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Modificar(TransporteUrbano dato)
        {
            try
            {
                string cmd = "UPDATE dbo.TransporteUrbano SET descripcion = ('" + dato.Descripcion + "'),linea = ('" + dato.Linea + "') WHERE transporteurb=" + dato.Id + " ";
                ConexionBaseDatos.EjecutarSql(cmd);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public TransporteUrbano BuscarXId(int id)
        {
            string cmdText = "SELECT id_transporteurb, descripcion, linea FROM dbo.TransporteUrbano WHERE id_transporteurb = " + Convert.ToString(id);
            try
            {
                DataTable dtNiveles = ConexionBaseDatos.CargarDatos(cmdText);
                foreach (DataRow aux in dtNiveles.Rows)
                {
                    TransporteUrbano trans = new TransporteUrbano(Convert.ToInt32(aux["id_transporteurb"]), aux["descripcion"].ToString(), Convert.ToInt32(aux["linea"]));
                    return trans;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se encontro el Transporte con id " + Convert.ToString(id), ex);
            }
            return null;
        }

        public List<TransporteUrbano> TraerTodos()
        {
            try
            {
                List<TransporteUrbano> listaTransporteAux = new List<TransporteUrbano>();
                string cmd = "select * from dbo.TransporteUrbano";
                DataTable dtNiveles = ConexionBaseDatos.CargarDatos(cmd);
                foreach (DataRow aux in dtNiveles.Rows)
                {
                    TransporteUrbano nivel = new TransporteUrbano(Convert.ToInt32(aux["id_transporteurb"]), aux["descripcion"].ToString(),Convert.ToInt32(aux["linea"]));
                    listaTransporteAux.Add(nivel);
                }
                return listaTransporteAux;
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
    }
}
