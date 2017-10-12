using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using System.Data;
using System.Data.SqlClient;

namespace Dao
{
    public class BD_Usuario : Singleton<BD_Usuario>, IDao<Usuario>
    {
        public BD_InstitucionEducativa bd_institucion = new BD_InstitucionEducativa();
        

        public BD_Rol bdroles = new BD_Rol();
        public void Agregar(Usuario dato)    //No se puede insertar el valor NULL en la columna 'id_institucion', tabla 'Prueba.dbo.Usuario'. La columna no admite valores NULL. Error de INSERT.  
        {
            try
            {
                string cmd;
                if(dato.MiInstitucion != null)
                    cmd = "INSERT INTO dbo.Usuario (dni,apellido,email,pass,id_rol,id_institucion) VALUES ('" + dato.Dni + "','" + dato.Apellido + "','" + dato.Email + "','" + dato.Pass + "','" + dato.MiRol.Id.ToString() + "','" + dato.MiInstitucion.Id.ToString() + "')";
                else
                    cmd = "INSERT INTO dbo.Usuario (dni,apellido,email,pass,id_rol) VALUES ('" + dato.Dni + "','" + dato.Apellido + "','" + dato.Email + "','" + dato.Pass + "','" + dato.MiRol.Id.ToString() + "')";

                ConexionBaseDatos.EjecutarSql(cmd);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Remover(Usuario dato)
        {
            try
            {
                string cmd = "delete from dbo.Usuario where(id_usuario=" + dato.Id + ")";
                ConexionBaseDatos.EjecutarSql(cmd);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Modificar(Usuario dato)
        {
            try
            {
                string cmd = "UPDATE dbo.Usuario SET dni = ('" + dato.Dni + "'), apellido = ('" + dato.Apellido + "'), email = ('" + dato.Email + "') WHERE id_usuario=" + dato.Id + " ";
                ConexionBaseDatos.EjecutarSql(cmd);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<Usuario> TraerTodos()   // modificar el is null
        {
            try
            {
                List<Usuario> listaUsuariosAux = new List<Usuario>();
                string cmd = "select * from dbo.Usuario";
                DataTable dtNiveles = ConexionBaseDatos.CargarDatos(cmd);
                foreach (DataRow aux in dtNiveles.Rows)
                {
                    Usuario user = new Usuario();
                    user.Apellido=aux["apellido"].ToString();
                    user.Dni=aux["dni"].ToString();
                    user.Email=aux["email"].ToString();
                    user.Pass=aux["pass"].ToString();
                    user.Id=Convert.ToInt32(aux["id_usuario"]);
                    user.MiRol=bdroles.buscarPorId(Convert.ToInt32(aux["id_rol"]));
                    if (aux["id_institucion"].ToString()!="")
                        user.MiInstitucion = bd_institucion.buscarPorId(Convert.ToInt32(aux["id_institucion"]));
                    else
                        user.MiInstitucion = null;
                    listaUsuariosAux.Add(user);
                }
                return listaUsuariosAux;
            }
            catch (SqlException ex)
            {
                throw ex ;
            }
        }

        public int ObtenerID()
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorEmail(string e)
        {
            string cmdText = "SELECT id_usuario,dni,apellido,email,pass,id_rol,id_institucion FROM dbo.Usuario WHERE email = '"+e.ToString()+"'";
            try
            {
                DataTable dtNiveles = ConexionBaseDatos.getData(cmdText);
                Usuario user = new Usuario();
                foreach (DataRow aux in dtNiveles.Rows)
                {
                    
                    user.Apellido = aux["apellido"].ToString();
                    user.Dni = aux["dni"].ToString();
                    user.Email = aux["email"].ToString();
                    user.Pass = aux["pass"].ToString();
                    user.Id = Convert.ToInt32(aux["id_usuario"]);
                    user.MiRol = bdroles.buscarPorId(Convert.ToInt32(aux["id_rol"]));
                    if (aux["id_institucion"].ToString()!="") //CONTROLAR ESTO CUANDO RETORNA NULL DE LA BASE DE DATOS
                        user.MiInstitucion = bd_institucion.buscarPorId(Convert.ToInt32(aux["id_institucion"]));
                }
                return user;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
