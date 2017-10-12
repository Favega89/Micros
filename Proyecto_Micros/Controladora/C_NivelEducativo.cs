using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Dao;

namespace Controladora
{
    public class C_NivelEducativo 
    {
        Lista_NivelEducativo datos = Lista_NivelEducativo.Instance();
        // BD_NivelEducativo datos = BD_NivelEducativo.Instance();
        NivelEducativo nivel;

        public void Nuevo(string descripcion)
        {
            nivel = new NivelEducativo();
            nivel.Descripcion = descripcion;
            //nivel.Id = datos.ObtenerID();
            datos.Agregar(nivel);
        }

        public NivelEducativo BuscarPorId(int id)
        {
            return datos.BuscarPorId(id);
        }

        public List<NivelEducativo> TraerTodos()
        {
            return datos.TraerTodos();
        }

        public void borrarXPos(int pos)
        {
            List<NivelEducativo> lista;
            lista=datos.TraerTodos();
            datos.Remover(lista[pos]);
        }

        public NivelEducativo buscarXpos(int pos)
        {
            List<NivelEducativo> lista = datos.TraerTodos();
            return lista[pos];
        }

        public void editarXPos(int pos, string des)
        {
            List<NivelEducativo> lista;
            lista = datos.TraerTodos();
            lista[pos].Descripcion = des;
            datos.Modificar(lista[pos]);
        }

        public bool comprobarDescripcion(string descri) //devuelve true si existe el mail, false si no existe
        {
            List<NivelEducativo> listaAux = new List<NivelEducativo>();
            listaAux = datos.TraerTodos();
            for (int i = 0; i < listaAux.Count; i++)
                if (listaAux[i].Descripcion == descri)
                    return true;
            return false;
        }
    }
}
