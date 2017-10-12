using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;

namespace Dao
{
    public class Lista_InstitucionEducativa : Singleton<Lista_InstitucionEducativa>, IDao<InstitucionEducativa>
    {
        private List<InstitucionEducativa> lista_InstitucionEducativa = new List<InstitucionEducativa>();

        public void Agregar(InstitucionEducativa dato)
        {
            lista_InstitucionEducativa.Add(dato);
        }

        public void Remover(InstitucionEducativa dato)
        {
            lista_InstitucionEducativa.Remove(dato);
        }

        public void Modificar(InstitucionEducativa dato)
        {
            lista_InstitucionEducativa = TraerTodos();

            for (int i = 0; i < lista_InstitucionEducativa.Count - 1; i++)
            {
                if (lista_InstitucionEducativa[i].Id == dato.Id)
                {
                    lista_InstitucionEducativa[i] = dato;
                }
            }
        }

        public List<InstitucionEducativa> TraerTodos()
        {
            return lista_InstitucionEducativa;
        }

        public int ObtenerID() //busca el ultimo e incrementa el id
        {
            int i;
            lista_InstitucionEducativa = TraerTodos();
            try
            {
                i = lista_InstitucionEducativa.Last().Id + 1;
            }
            catch
            {
                i = 1;
            }
            return i;
        }

        public InstitucionEducativa buscarPorId(int aux)
        {
            lista_InstitucionEducativa = TraerTodos();
            for (int i = 0; i < lista_InstitucionEducativa.Count; i++)
                if (lista_InstitucionEducativa[i].Id==aux)
                    return lista_InstitucionEducativa[i];
            return null;
        }
    }
}
