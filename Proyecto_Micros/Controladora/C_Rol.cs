using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Dao;

namespace Controladora
{
    public class C_Rol
    {
        Lista_Rol datos = Lista_Rol.Instance();
        // BD_Rol datos = BD_Rol.Instance();

        public void nuevo(string desc)
        {
            Rol roro = new Rol();
            //roro.Id = id;
            roro.Descripcion = desc;
            datos.Agregar(roro);
        }
        public List<Rol> TraerTodos()
        {
            return datos.TraerTodos();
        }
        public int buscarUltimoId()
        {
            return datos.ObtenerID();
        }
        public Rol buscarPorId(int i)
        {
            return datos.buscarPorId(i);
        }

        public bool comprobarDescripcion(string descri) //devuelve true si existe el mail, false si no existe
        {
            List<Rol> listaAux = new List<Rol>();
            listaAux = datos.TraerTodos();
            for (int i = 0; i < listaAux.Count; i++)
                if (listaAux[i].Descripcion == descri)
                    return true;
            return false;
        }
    }
    
}
