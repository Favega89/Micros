using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;

namespace Dao
{
    public class Lista_TransporteUrbano : Singleton<Lista_TransporteUrbano>, IDao<TransporteUrbano>
    {
        private List<TransporteUrbano> lista_TransporteUrbano = new List<TransporteUrbano>();

        public void Agregar(TransporteUrbano dato)
        {
            lista_TransporteUrbano.Add(dato);
        }

        public void Remover(TransporteUrbano dato)
        {
            lista_TransporteUrbano.Remove(dato);
        }

        public void Modificar(TransporteUrbano dato)
        {
            lista_TransporteUrbano = TraerTodos();

            for (int i = 0; i < lista_TransporteUrbano.Count - 1; i++)
            {
                if (lista_TransporteUrbano[i].Id == dato.Id)
                {
                    lista_TransporteUrbano[i] = dato;
                }
            }
        }

        public List<TransporteUrbano> TraerTodos()
        {
            return lista_TransporteUrbano;
        }
        public int ObtenerID()
        {
            lista_TransporteUrbano = TraerTodos();
            if (lista_TransporteUrbano.Count != 0)
                return lista_TransporteUrbano.Last().Id + 1;
            else
                return 1;
        }
    }
}
