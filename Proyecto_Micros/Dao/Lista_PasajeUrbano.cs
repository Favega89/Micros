using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
namespace Dao
{
    public class Lista_PasajeUrbano : Singleton<Lista_PasajeUrbano>, IDao<PasajeUrbano>
    {
        private List<PasajeUrbano> lista_PasajeUrbano = new List<PasajeUrbano>();

        public void Agregar(PasajeUrbano dato)
        {
            lista_PasajeUrbano.Add(dato);
        }

        public void Remover(PasajeUrbano dato)
        {
            lista_PasajeUrbano.Remove(dato);
        }

        public void Modificar(PasajeUrbano dato)
        {
            lista_PasajeUrbano = TraerTodos();

            for (int i = 0; i < lista_PasajeUrbano.Count - 1; i++)
            {
                if (lista_PasajeUrbano[i].Id == dato.Id)
                {
                    lista_PasajeUrbano[i] = dato;
                }
            }
        }

        public List<PasajeUrbano> TraerTodos()
        {
            return lista_PasajeUrbano;
        }
        public int ObtenerID() //busca el ultimo e incrementa el id
        {
            int i;
            lista_PasajeUrbano = TraerTodos();
            if (lista_PasajeUrbano.Count == 1)
                return 2;
            try
            {
                i = lista_PasajeUrbano.Last().Id + 1;
            }
            catch
            {
                i = 1;
            }
            return i;
        }
    }
}
