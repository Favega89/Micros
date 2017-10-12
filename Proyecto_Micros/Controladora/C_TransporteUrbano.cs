using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Controladora;
using Dao;

namespace Controladora
{
    public class C_TransporteUrbano
    {
        //Lista_TransporteUrbano datos = Lista_TransporteUrbano.Instance();
        BD_TransporteUrbano datos = BD_TransporteUrbano.Instance();
        TransporteUrbano transporte;

        public void Nuevo(string descripcion, int linea)
        {
            transporte = new TransporteUrbano();
            transporte.Descripcion = descripcion;
            transporte.Linea = linea;
            datos.Agregar(transporte);
        }

        public List<TransporteUrbano> TraerTodos()
        {
            return datos.TraerTodos();
        }

        public void borrarXPos(int dato)
        {
            List<TransporteUrbano> lista;
            lista = datos.TraerTodos();
            datos.Remover(lista[dato]);
        }
        public int buscarUltimoId()
        {
            return datos.ObtenerID();
        }
    }
}
