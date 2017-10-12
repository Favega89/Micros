using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Estudiante
    {
        //atributos
        private int id;
        private string apellido;
        private string nombre;
        private string telefono;
        private string dni;
        private Boolean activo;
        private DateTime fechaNacimiento;
        private InstitucionEducativa InstitucionEducativa;
        private NivelEducativo NivelEducativo;

        //propiedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public Boolean Activo
        {
            get { return activo; }
            set { activo = value; }
        }
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }
        public InstitucionEducativa InstitucionEducativa1
        {
            get { return InstitucionEducativa; }
            set { InstitucionEducativa = value; }
        }
        public NivelEducativo NivelEducativo1
        {
            get { return NivelEducativo; }
            set { NivelEducativo = value; }
        } 

        //constructor AGREGAR LOS OBJETOS
        public Estudiante() : base()
        {
            id = 0;
            apellido = "";
            nombre = "";
            telefono = "";
            dni = "";
            activo = true;
            FechaNacimiento = DateTime.Today;
            InstitucionEducativa = null;
            NivelEducativo = null;
        }
        public Estudiante(int ident, String documen, String nomb, String apell, DateTime fecha,InstitucionEducativa ins,NivelEducativo niv,string tel)
        {
            id = ident;
            apellido = apell;
            nombre = nomb;
            telefono = tel;
            dni = documen;
            activo = true;
            FechaNacimiento = fecha;
            InstitucionEducativa = ins;
            NivelEducativo = niv;
        }

        //metodos
            
    }
}
