using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;

namespace Dao
{
    public class Lista_Usuario :Singleton<Lista_Usuario>,IDao<Usuario>
    {
        private List<Usuario> lista_Usuario = new List<Usuario>();
        public Lista_InstitucionEducativa bd_institucion = new Lista_InstitucionEducativa();

        public void Agregar(Usuario dato)
        {
         //   lista_Usuario.RemoveAt(0);
            lista_Usuario.Add(dato);
        }

        public void Remover(Usuario dato)
        {
            lista_Usuario.Remove(dato);
        }

        public void Modificar(Usuario dato)
        {
            lista_Usuario = TraerTodos();

            for (int i = 0; i < lista_Usuario.Count - 1; i++)
            {
                if (lista_Usuario[i].Id == dato.Id)
                {
                    lista_Usuario[i] = dato;
                }
            }
        }

        public List<Usuario> TraerTodos()
        {
            return lista_Usuario;
        }

        public int ObtenerID() //busca el ultimo e incrementa el id
        {
            int i;
            lista_Usuario = TraerTodos();
            try
            {
                i = lista_Usuario.Last().Id + 1;
            }
            catch
            {
                i = 1;
            }
            return i;
        }

        public Usuario BuscarPorEmail(string e)
        {
            lista_Usuario = TraerTodos();
            for (int i = 0; i < lista_Usuario.Count; i++)
                if (lista_Usuario[i].Email == e)
                    return lista_Usuario[i];
            return null;
        }
    }
}
