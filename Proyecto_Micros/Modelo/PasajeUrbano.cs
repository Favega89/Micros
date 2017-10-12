using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class PasajeUrbano
    {
        //atributos
        int id;
        DateTime fecha_hora;
        Estudiante estudiante;
        TransporteUrbano transpUrb;

        //propiedades
        public int Id
        {
            get{ return id;}
            set{id = value;}
        }
        public DateTime Fecha_Hora
        {
            get{return fecha_hora;}
            set{fecha_hora = value;}
        }
        public Estudiante Estudiante
        {
            get { return estudiante; }
            set { estudiante = value; }
        }
        public TransporteUrbano TranspUrb
        {
            get { return transpUrb; }
            set { transpUrb = value; }
        }

        //constructores
        public PasajeUrbano()
        {
            id = 0;
            Fecha_Hora=DateTime.Today;
            estudiante = null;
            transpUrb = null;
        }

        public PasajeUrbano(int ident , DateTime fyh, Estudiante est,TransporteUrbano trans)
        {
            id = ident;
            fecha_hora = fyh;
            estudiante = est;
            transpUrb = trans;
        }
    }
}
