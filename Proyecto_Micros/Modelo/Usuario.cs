using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Usuario
    {
        //atributos
        private int id;
        private string dni;
        private string apellido;
        private string email;
        private string pass;
        private Rol miRol;
        private InstitucionEducativa miInstitucion;

       //propiedades
        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Rol MiRol
        {
            get { return miRol; }
            set { miRol = value; }
        }
        public InstitucionEducativa MiInstitucion
        {
            get { return miInstitucion; }
            set { miInstitucion = value; }
        }

        //constructor
        public Usuario()
        {
            id = 0;
            dni = "";
            apellido = "";
            email = "";
            pass = "";
            miRol = new Rol();
            miInstitucion = new InstitucionEducativa();
        }
        public Usuario(int a,string b,string c,string d,string e,Rol f,InstitucionEducativa g)
        {
            id = a;
            dni = b;
            apellido = c;
            email = d;
            pass = e;
            miRol = f;
            miInstitucion = g;
        }

        //metodos
    }
}
