using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class TransporteUrbano
    {
        //atributos
        private int id;
        private string descripcion;
        private int linea;

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
        public int Linea
        {
            get { return linea; }
            set { linea = value; }
        }

        //constructores
        public TransporteUrbano()
        {
            id = 0;
            descripcion = "";
            linea = 0;
        }
        public TransporteUrbano(int iden,string descri,int li)
        {
            id = iden;
            descripcion = descri;
            linea = li;
        }
        
    }
}
