using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using System.Data;
using System.Data.SqlClient;



namespace Dao
{
    public class BD_PasajeUrbano : Singleton<BD_PasajeUrbano> , IDao <PasajeUrbano>
    {
        public void Agregar(PasajeUrbano dato)//int id;DateTime fecha_hora;Estudiante estudiante; TransporteUrbano transpUrb;int autenticacion; int nroInterno;
        {
            try
            {
                string cmd = "INSERT INTO dbo.PasajeUrbano (id_pasajeurb,fecha_hora,id_transporteurb,id_estudiante) VALUES ('" + dato.Id + "','" + dato.Fecha_Hora + "','" + dato.TranspUrb.Id + "','" + dato.Estudiante.Id + "')";
                ConexionBaseDatos.EjecutarSql(cmd);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Remover(PasajeUrbano dato)
        {
            try
            {
                string cmd = "delete from dbo.PasajeUrbano where(id_pasajeurb=" + dato.Id + ")";
                ConexionBaseDatos.EjecutarSql(cmd);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Modificar(PasajeUrbano dato)
        {
            throw new NotImplementedException();
        }

        public List<PasajeUrbano> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public List<PasajeUrbano> TraerTodosPorIdEstudiante()
        {
            throw new NotImplementedException();
        }

        public PasajeUrbano BuscarxId()
        {
            throw new NotImplementedException();
        }
    }
}
