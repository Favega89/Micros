using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;

namespace Dao
{
    public class Lista_Rol:Singleton<Lista_Rol>,IDao<Rol>
    {
        private List<Rol> lista_Rol = new List<Rol>();

        public void Agregar(Rol dato)
        {
            lista_Rol.Add(dato);
        }

        public void Remover(Rol dato)
        {
            lista_Rol.Remove(dato);
        }

        public void Modificar(Rol dato)
        {
            lista_Rol = TraerTodos();

            for (int i = 0; i < lista_Rol.Count - 1; i++)
            {
                if (lista_Rol[i].Id == dato.Id)
                {
                    lista_Rol[i] = dato;
                }
            }
        }

        public List<Rol> TraerTodos()
        {
            return lista_Rol;
        }
        public int ObtenerID() //busca el ultimo e incrementa el id
        {
            int i;
            lista_Rol = TraerTodos();
            try
            {
                i = lista_Rol.Last().Id + 1;
            }
            catch
            {
                i = 1;
            }
            return i;
        }
        public Rol buscarPorId(int x)
        {
            lista_Rol= TraerTodos();
            Rol aux = new Rol();
            try
            {
                for (int i = 0; i < lista_Rol.Count; i++)
                    if (lista_Rol[i].Id == x)
                        aux= lista_Rol[i];
            }
            catch
            {
                aux=null;
            }
            return aux;
        }
    }
}
