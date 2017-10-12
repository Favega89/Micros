using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using System.Data;
using System.Data.SqlClient;

namespace Dao
{
    public class BD_Estudiante : Singleton <BD_Estudiante> , IDao <Estudiante>
    {
        BD_InstitucionEducativa bd_insti = new BD_InstitucionEducativa();
        BD_NivelEducativo bd_niveledu = new BD_NivelEducativo();

        public void Agregar(Estudiante dato)
        {
            try
            {
                int activo;
                if (dato.Activo)
                    activo = 1;
                else
                    activo = 0;
                string cmd = "INSERT INTO dbo.Estudiante (apellido,nombre,telefono,dni,fechanacimiento,id_niveleduc,id_institucion,activo) VALUES ('" + dato.Apellido + "','" + dato.Nombre + "','" + dato.Telefono + "','" + dato.Dni + "','" + dato.FechaNacimiento + "','" + dato.NivelEducativo1.Id + "','" + dato.InstitucionEducativa1.Id + "','"+ activo + "')";
                ConexionBaseDatos.EjecutarSql(cmd);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Remover(Estudiante dato)
        {
            try
            {
                string cmd = "delete from dbo.Estudiante where(id_estudiante=" + dato.Id + ")";
                ConexionBaseDatos.EjecutarSql(cmd);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Modificar(Estudiante dato)
        {
            try
            {
                string cmd = "UPDATE dbo.Estudiante SET nombre = ('" + dato.Nombre + "'), apellido = ('" + dato.Apellido + "'), dni = ('" + dato.Dni + "'), telefono = ('" + dato.Telefono + "') WHERE id_estudiante=" + dato.Id + " ";
                ConexionBaseDatos.EjecutarSql(cmd);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        public List<Estudiante> TraerTodos()
        {
            List<Estudiante> listaEstudiantesAux = new List<Estudiante>();
            string cmd = "select * from dbo.Estudiante";
            try
            {
                DataTable dtNiveles = ConexionBaseDatos.CargarDatos(cmd);
                foreach (DataRow aux in dtNiveles.Rows)
                {
                    Estudiante estu = new Estudiante();
                    estu.Apellido = aux["apellido"].ToString();
                    estu.Nombre = aux["nombre"].ToString();
                    estu.Dni = aux["dni"].ToString();
                    estu.Telefono = aux["telefono"].ToString();
                    estu.Id = Convert.ToInt32(aux["id_estudiante"]);
                    if (Convert.ToInt32(aux["activo"]) == 0)
                        estu.Activo = true;
                    else
                        estu.Activo = false;
                    estu.InstitucionEducativa1 = bd_insti.buscarPorId(Convert.ToInt32(aux["id_institucion"]));
                    estu.NivelEducativo1 = bd_niveledu.BuscarPorId(Convert.ToInt32(aux["id_niveleduc"]));
                    listaEstudiantesAux.Add(estu);
                }
                return listaEstudiantesAux;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public Estudiante buscarXId(int i)
        {
            string cmdText = "select p.id_estudiante, p.apellido,p.nombre,p.telefono,p.dni,p.activo,p.fechanacimiento, p.id_institucion, a.descripcion, p.id_niveleduc, q.descripcion from dbo.Estudiante as p inner join dbo.InstitucionEducativa as a on p.id_institucion = a.id_institucion inner join dbo.NivelEducativo as q on p.id_niveleduc = q.id_niveleduc where id_estudiante = '" + Convert.ToString(i)+"'";
            try
            {
                DataTable dtNiveles = ConexionBaseDatos.CargarDatos(cmdText);
                foreach (DataRow aux in dtNiveles.Rows)
                {
                    Estudiante estu = new Estudiante();
                    estu.Id = Convert.ToInt32(aux["id_estudiante"]);
                    estu.Apellido = aux["apellido"].ToString();
                    estu.Nombre = aux["nombre"].ToString();
                    estu.Telefono = aux["telefono"].ToString();
                    estu.Dni = aux["dni"].ToString();
                    if (Convert.ToInt32(aux["activo"]) == 1)
                        estu.Activo = true;
                    else
                        estu.Activo = false;
                    estu.FechaNacimiento = (DateTime)aux["fechanacimiento"];
                    estu.InstitucionEducativa1 = bd_insti.buscarPorId(Convert.ToInt32(aux["id_institucion"]));
                    estu.NivelEducativo1 = bd_niveledu.BuscarPorId(Convert.ToInt32(aux["id_niveleduc"]));
                    return estu;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se encontro el estudiante con id " + Convert.ToString(i), ex);
            }
            return null;
        }
    }
}
