using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Dao;

namespace Controladora
{
    public class C_InstitucionEducativa
    {
        public C_NivelEducativo ctrlNivelEducativo = new C_NivelEducativo();
        InstitucionEducativa inst = new InstitucionEducativa();
        Lista_InstitucionEducativa datos = Lista_InstitucionEducativa.Instance();
        // BD_InstitucionEducativa datos = BD_InstitucionEducativa.Instance();

        public void Nuevo(string descripcion,List<int> lista)
        {
            inst.Descripcion = descripcion;
            //inst.Id = datos.ObtenerID();
            for (int i = 0; i < lista.Count; i++)
                 inst.Lista_nivelEducativos.Add(ctrlNivelEducativo.BuscarPorId(lista[i]));          
            datos.Agregar(inst);
        }

        public List<InstitucionEducativa> TraerTodos()
        {
            return datos.TraerTodos();
        }

        public void BorrarXpos(int pos)
        {
            List<InstitucionEducativa> lista = datos.TraerTodos();
            datos.Remover(lista[pos]);
        }


        public InstitucionEducativa buscarXpos(int pos)
        {
            List<InstitucionEducativa> lista = datos.TraerTodos();
            return lista[pos];
        }

        public void EditarXpos(int pos, string descripcion, List<int> listaInt)
        {
            List<InstitucionEducativa> lista = datos.TraerTodos();
            InstitucionEducativa aux = lista[pos];
            aux.Descripcion = descripcion;
            aux.Lista_nivelEducativos = new List<NivelEducativo>();
            for (int i = 0; i < listaInt.Count; i++)
                aux.Lista_nivelEducativos.Add(ctrlNivelEducativo.BuscarPorId(listaInt[i]));
            datos.Modificar(lista[pos]);
        }

        public bool comprobarDescripcion(string descri) //devuelve true si existe el mail, false si no existe
        {
            List<InstitucionEducativa> listaAux = new List<InstitucionEducativa>();
            listaAux = datos.TraerTodos();
            for (int i = 0; i < listaAux.Count; i++)
                if (listaAux[i].Descripcion == descri)
                    return true;
            return false;
        }
    }
}
