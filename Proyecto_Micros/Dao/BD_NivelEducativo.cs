using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using System.Data;
using System.Data.SqlClient;

namespace Dao
{
    public class BD_NivelEducativo : Singleton<BD_NivelEducativo>, IDao <NivelEducativo>
    {
        public void Agregar(NivelEducativo dato)
        {
           try
            {
                string cmd = "INSERT INTO dbo.NivelEducativo (descripcion) VALUES ('" + dato.Descripcion+"')";
                ConexionBaseDatos.EjecutarSql(cmd);
            }
           catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Remover(NivelEducativo dato)
        {
            try
            {
                string cmd = "delete from dbo.NivelEducativo where(id_niveleduc=" + dato.Id + ")";
                ConexionBaseDatos.EjecutarSql(cmd);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Modificar(NivelEducativo dato)
        {
            try
            {
                string cmd = "UPDATE dbo.NivelEducativo SET descripcion = ('" + dato.Descripcion + "') WHERE id_niveleduc=" + dato.Id + " ";
                ConexionBaseDatos.EjecutarSql(cmd);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<NivelEducativo> TraerTodos()
        {
            try
            {
                List<NivelEducativo> listaNivelesAux = new List<NivelEducativo>();
                string cmd = "select * from dbo.NivelEducativo";
                DataTable dtNiveles = ConexionBaseDatos.CargarDatos(cmd);
                foreach (DataRow aux in dtNiveles.Rows)
                {
                    NivelEducativo nivel = new NivelEducativo(Convert.ToInt32(aux["id_niveleduc"]),aux["descripcion"].ToString());
                    listaNivelesAux.Add(nivel);
                }
                return listaNivelesAux;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public NivelEducativo BuscarPorId(int id)
        {
            string cmdText = "SELECT id_niveleduc, descripcion FROM dbo.NivelEducativo WHERE id_niveleduc = " + Convert.ToString(id);
            try
            {
                //NivelEducativo nivel = this.searchOneBy(cmdText);
                DataTable dtNiveles = ConexionBaseDatos.CargarDatos(cmdText);
                foreach (DataRow aux in dtNiveles.Rows)
                {
                    NivelEducativo nivel = new NivelEducativo(Convert.ToInt32(aux["id_niveleduc"]), aux["descripcion"].ToString());
                    return nivel;
                } 
            }
            catch (SqlException ex)
            {
                throw new Exception("No se encontro el usuario con id " + Convert.ToString(id), ex);
            }
            return null;
        }
    }
}


