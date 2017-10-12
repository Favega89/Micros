using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Dao;

namespace Controladora
{
    public class C_PasajeUrbano 
    {
        // Lista_PasajeUrbano datos = Lista_PasajeUrbano.Instance();
        BD_PasajeUrbano datos = BD_PasajeUrbano.Instance();
        PasajeUrbano pas;

        public void Nuevo(int id,TransporteUrbano trans,DateTime fech) //falta pasar el estudiante!!!!!
        {
            pas = new PasajeUrbano();
            pas.Id = id;
            pas.TranspUrb = trans;
            pas.Fecha_Hora = fech;
            //pas.Estudiante = est;
            datos.Agregar(pas);
        }

        /*public int buscarUltimoId()
        {
            return datos.ObtenerID();
        }*/
    }
}
