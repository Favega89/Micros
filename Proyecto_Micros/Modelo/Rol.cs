using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Rol        //con id=1 es administrador, con id=2 es RespInstEduc. con id=3 estudiante
    {  
        //atributos
        private int id;
        private string descripcion;

        //propiedades
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        //constructor
        public Rol()
        {
            id = 0;
            descripcion = "";
        }
        public Rol(int a, string b)
        {
            id = a;
            descripcion = b;
        }
        
    }
}
