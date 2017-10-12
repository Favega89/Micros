using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class InstitucionEducativa
    {
        //atributos
        private int id;
        private String descripcion;
        private List<NivelEducativo> lista_nivelEducativos;

        //propiedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public List<NivelEducativo> Lista_nivelEducativos
        {
            get { return lista_nivelEducativos; }
            set { lista_nivelEducativos = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string DescripcionNivelEducativo
        {
            
            get {
                string desc = "";
                    for (int i = 0; i < lista_nivelEducativos.Count; i++)
                    {
                        desc = desc +" "+this.lista_nivelEducativos[i].Descripcion;
                    }
                    return desc;
                }
        }


        //constructores
        public InstitucionEducativa()
        {
            Id = 0;
            Descripcion = "";
            Lista_nivelEducativos = new List<NivelEducativo>();
        }

        public InstitucionEducativa(int ident, String descrip, List<NivelEducativo> li)
        {
            Id = ident;
            Descripcion = descrip;
            Lista_nivelEducativos = li;
        }

        //metodos


    }
}
