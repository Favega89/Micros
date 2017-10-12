using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Dao;

namespace Controladora
{
    public class C_Estudiante
    {
        Estudiante est = new Estudiante();
        C_NivelEducativo ctrlNivel = new C_NivelEducativo();
        Lista_Estudiante datos = Lista_Estudiante.Instance();
       // BD_Estudiante datos = BD_Estudiante.Instance();

        public void Nuevo(string dni, string nom, string ape, DateTime fnac,string tel,int ne,InstitucionEducativa inte)//falta ahgregar ,int idNivelEducativo
        {
            est.Dni = dni;
            est.Nombre = nom;
            est.Apellido = ape;
            est.Telefono = tel;
            est.FechaNacimiento = fnac;
            est.InstitucionEducativa1 = inte;
            est.NivelEducativo1 = ctrlNivel.BuscarPorId(ne);
            datos.Agregar(est);
        }

        public void Remover(int i)
        {
            Estudiante e = new Estudiante();
            e.Id = i;
            datos.Remover(e);
        }

        public void Modificar(int pos, string nombre, string apellido, string dni, string telefono)
        {
            Estudiante e = new Estudiante();
            e.Id = pos;
            e.Nombre = nombre;
            e.Apellido = apellido;
            e.Dni = dni;
            e.Telefono = telefono;
            datos.Modificar(e);
        }

        public bool ComprobarDni(string dni)    //devuelve true si existe el mail, false si no existe
        {
            List<Estudiante> listaEstudianteAux = new List<Estudiante>();
            listaEstudianteAux = datos.TraerTodos();
            for (int i = 0; i < listaEstudianteAux.Count; i++)
            {
                if (listaEstudianteAux[i].Dni == dni)
                    return true;
            }
            return false;
        }

        public List<Estudiante> TraerPorInstitucion(InstitucionEducativa inst)
        {
            List<Estudiante> lista = new List<Estudiante>();
            List<Estudiante> listaTodos = new List<Estudiante>();
            listaTodos = datos.TraerTodos();
            for (int i = 0; i < listaTodos.Count; i++)
            {
                if (listaTodos[i].InstitucionEducativa1.Id == inst.Id)
                    lista.Add(listaTodos[i]);
            }
            return lista;
        }
    }
}
