using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class NivelEducativo
    {
        //atributos
        private int id;
        private string descripcion;

        //propiedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        //constructor
        public NivelEducativo()
        {
            Id = 0;
            Descripcion = "";
        }
        public NivelEducativo(int ident, String descrip)
        {
            Id = ident;
            Descripcion = descrip;
        }

        //metodos

    }
}
