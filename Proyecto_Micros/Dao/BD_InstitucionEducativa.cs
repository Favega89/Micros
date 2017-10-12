using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using System.Data;
using System.Data.SqlClient;

namespace Dao
{
    public 
        class BD_InstitucionEducativa : Singleton<BD_InstitucionEducativa>, IDao<InstitucionEducativa>
    {
        public void Agregar(InstitucionEducativa dato)
        {
            try
            {
                string cmd = "INSERT INTO dbo.InstitucionEducativa (descripcion) VALUES ('" + dato.Descripcion + "');select @@IDENTITY";
                //ConexionBaseDatos.EjecutarSql(cmd);
                //string can = "select @@IDENTITY";
                int aux3 = ConexionBaseDatos.EjecutarEscalar(cmd);
                foreach (NivelEducativo aux in dato.Lista_nivelEducativos)
                {
                    string com = "INSERT INTO dbo.Rela_Institucion_Nivel (id_institucion,id_niveleduc) VALUES ('" + aux3 + "','" + aux.Id + "')";
                    ConexionBaseDatos.EjecutarSql(com);
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Remover(InstitucionEducativa dato)
        {
            try
            {
                string cmd = "delete from dbo.InstitucionEducativa where(id_institucion=" + dato.Id + ")";
                ConexionBaseDatos.EjecutarSql(cmd);
                string com = "delete from dbo.Rela_Institucion_Nivel where (id_institucion=" + dato.Id + ")";
                ConexionBaseDatos.EjecutarSql(com);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Modificar(InstitucionEducativa dato)    //hacer el modificar
        {
            try
            {
                string cmd = "UPDATE dbo.InstitucionEducativa SET descripcion = ('" + dato.Descripcion + "') WHERE id_institucion=" + dato.Id + " ";
                ConexionBaseDatos.EjecutarSql(cmd);
                string com = "DELETE from dbo.Rela_Institucion_Nivel where (id_institucion=" + dato.Id + ")";
                ConexionBaseDatos.EjecutarSql(com);
                foreach (NivelEducativo aux in dato.Lista_nivelEducativos)
                {
                    string cmt = "INSERT INTO dbo.Rela_Institucion_Nivel (id_institucion,id_niveleduc) VALUES ('" + dato.Id + "','" + aux.Id + "')";
                    ConexionBaseDatos.EjecutarSql(cmt);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<InstitucionEducativa> TraerTodos()
        {
            try
            {
                List<InstitucionEducativa> listaInstitucionesAux = new List<InstitucionEducativa>();
                string cmd = "select * from dbo.InstitucionEducativa";
                DataTable dtNiveles = ConexionBaseDatos.CargarDatos(cmd);
                foreach (DataRow aux in dtNiveles.Rows)
                {
                    InstitucionEducativa inst = new InstitucionEducativa();
                    inst.Id = Convert.ToInt32(aux["id_institucion"]);
                    inst.Descripcion = aux["descripcion"].ToString();
                    
                    string com = "select * from dbo.Rela_Institucion_Nivel";
                    DataTable dtNivel = ConexionBaseDatos.CargarDatos(com);
                    foreach (DataRow aux2 in dtNivel.Rows)
                    {
                        if (Convert.ToInt32(aux2["id_institucion"]) == inst.Id)
                        {
                            string con = "Select * from dbo.NivelEducativo where (id_niveleduc = " + Convert.ToInt32(aux2["id_niveleduc"])+")";
                            DataTable dtNiv = ConexionBaseDatos.CargarDatos(con);
                            foreach (DataRow aux3 in dtNiv.Rows)
                            {
                                NivelEducativo nivel = new NivelEducativo(Convert.ToInt32(aux3["id_niveleduc"]), aux3["descripcion"].ToString());
                                inst.Lista_nivelEducativos.Add(nivel);
                            } 
                        }
                    }
                    listaInstitucionesAux.Add(inst);
                }
                return listaInstitucionesAux;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public InstitucionEducativa buscarPorId(int i)
        {
            string cmdText = "SELECT id_institucion, descripcion FROM dbo.InstitucionEducativa WHERE id_institucion = '"+Convert.ToString(i)+"'";
            try
            {
                DataTable dtRoles = ConexionBaseDatos.CargarDatos(cmdText);
                foreach (DataRow aux in dtRoles.Rows)
                {
                    InstitucionEducativa inst = new InstitucionEducativa();
                    inst.Descripcion = aux["descripcion"].ToString();
                    inst.Id = Convert.ToInt32(aux["id_institucion"]);

                    string com = "select * from dbo.Rela_Institucion_Nivel";
                    DataTable dtNivel = ConexionBaseDatos.CargarDatos(com);
                    foreach (DataRow aux2 in dtNivel.Rows)
                    {
                        if (Convert.ToInt32(aux2["id_institucion"]) == inst.Id)
                        {
                            string con = "Select * from dbo.NivelEducativo where (id_niveleduc = " + Convert.ToInt32(aux2["id_niveleduc"]) + ")";
                            DataTable dtNiv = ConexionBaseDatos.CargarDatos(con);
                            foreach (DataRow aux3 in dtNiv.Rows)
                            {
                                NivelEducativo nivel = new NivelEducativo(Convert.ToInt32(aux3["id_niveleduc"]), aux3["descripcion"].ToString());
                                inst.Lista_nivelEducativos.Add(nivel);
                            }
                        }
                    }
                    return inst;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se encontro el usuario con id " + Convert.ToString(i), ex);
            }
            return null;
        }

        public int ObtenerID()
        {
            throw new NotImplementedException();
        }
    }
}
