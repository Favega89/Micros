using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Dao;

namespace Controladora
{
    public class C_Usuario
    {
        public C_Rol ctrlRol = new C_Rol();
        public C_InstitucionEducativa ctrlInst = new C_InstitucionEducativa();
        
        Lista_Usuario datos = Lista_Usuario.Instance();
        //BD_Usuario datos = BD_Usuario.Instance();
        
        Usuario user = new Usuario();

        public List<Usuario> TraerTodos()
        {
            return datos.TraerTodos();
        }
        public void nuevo(string dni,string apellido,string email,string pass,int mirol,int miInstitucion)//falta recibir el rol
        {
            user.Dni = dni;
            user.Apellido = apellido;
            user.Email = email;
            user.Pass = pass;
            user.MiRol = ctrlRol.buscarPorId(mirol);
            if (miInstitucion == 0)
                user.MiInstitucion = null;
            else
                user.MiInstitucion = datos.bd_institucion.buscarPorId(miInstitucion);
            datos.Agregar(user);
        }

        public Boolean comprobar (string email,string pass)//con el email y pass comprueba que este bien cuano esta mal poner user invalido!!!!
        {
            //user=datos.BuscarPorEmail(email);
            //if (user != null)
                if (pass == "123")
                    return true;
            return false;
        }

        public Usuario buscarXemail(string e)
        {
            user = datos.BuscarPorEmail(e);
            if (user != null)
                return user;
            return null;
        }

        public void Remover(int i)
        {
            Usuario e = new Usuario();
            e.Id = i;
            datos.Remover(e);
        }

        public void Modificar(int pos, string dni, string apellido, string email)
        {
            Usuario e = new Usuario();
            e.Id = pos;
            e.Dni = dni;
            e.Apellido = apellido;
            e.Email = email;
            datos.Modificar(e);
        }
    }
}
