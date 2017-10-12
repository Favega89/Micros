using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dao
{
    interface IDao<T>
    {
        void Agregar(T dato);
        void Remover(T dato);
        void Modificar(T dato);
        List<T> TraerTodos();
    }
}
