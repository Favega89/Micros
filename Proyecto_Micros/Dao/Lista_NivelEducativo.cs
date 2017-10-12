using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;

namespace Dao
{
    public class Lista_NivelEducativo : Singleton<Lista_NivelEducativo>, IDao<NivelEducativo>
    {
        private List<NivelEducativo> lista_NivelEducativo = new List<NivelEducativo>();

        public void Agregar(NivelEducativo dato)
        {
            lista_NivelEducativo.Add(dato);
        }

        public void Remover(NivelEducativo dato)
        {
            lista_NivelEducativo.Remove(dato);
        }

        public void Modificar(NivelEducativo dato)
        {
            lista_NivelEducativo = TraerTodos();

            for (int i = 0; i < lista_NivelEducativo.Count - 1; i++)
            {
                if (lista_NivelEducativo[i].Id == dato.Id)
                {
                    lista_NivelEducativo[i] = dato;
                }
            }
        }

        public List<NivelEducativo> TraerTodos()
        {
            return lista_NivelEducativo;
        }

        public int ObtenerID() //busca el ultimo e incrementa el id
        {
            int i;
            lista_NivelEducativo = TraerTodos();
            try
            {
                i = lista_NivelEducativo.Last().Id + 1;
            }
            catch {
                i=1;
            }
            return i;
        }
        public NivelEducativo BuscarPorId(int id)
        {
            lista_NivelEducativo = TraerTodos();
            for (int i = 0; i < lista_NivelEducativo.Count; i++)
                if (lista_NivelEducativo[i].Id == id)
                    return lista_NivelEducativo[i];
            return null;
        }
    }
}
