using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;

namespace Dao
{
    public class Lista_Estudiante : Singleton<Lista_Estudiante>, IDao<Estudiante>
    {
        private List<Estudiante> lista_Estudiante = new List<Estudiante>();

        public void Agregar(Estudiante dato)
        {
            lista_Estudiante.Add(dato);
        }

        public void Remover(Estudiante dato)
        {
            lista_Estudiante.Remove(dato);
        }

        public void Modificar(Estudiante dato)
        {
            lista_Estudiante = TraerTodos();

            for (int i = 0; i < lista_Estudiante.Count - 1; i++)
            {
                if (lista_Estudiante[i].Id == dato.Id)
                {
                    lista_Estudiante[i] = dato;
                }
            }
        }

        public List<Estudiante> TraerTodos()
        {
            return lista_Estudiante;
        }
        public int ObtenerID() //busca el ultimo e incrementa el id
        {
            int i;
            lista_Estudiante = TraerTodos();
            try
            {
                i = lista_Estudiante.Last().Id + 1;
            }
            catch
            {
                i = 1;
            }
            return i;
        }
    }
}
