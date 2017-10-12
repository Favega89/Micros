using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Dao;
using Modelo;

/// <summary>
/// Descripción breve de Convert
/// </summary>
[WebService(Namespace = "http://localhost/", Name="Prueba")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class Convert : System.Web.Services.WebService {

    public Convert () {

        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hola a todos";
    }

    [WebMethod]
    public bool ComprobarEstudiante(int id)
    {
        BD_Estudiante bdEstu = new BD_Estudiante();
        List <Estudiante> lista = new  List<Estudiante>();
        lista = bdEstu.TraerTodos();
        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i].Id == id)
                return true;
        }
        return false;
    }

    [WebMethod]
    public List<TransporteUrbano> TraerTodosMicros()
    {
        BD_TransporteUrbano bdTransp = new BD_TransporteUrbano();
        return bdTransp.TraerTodos();
    }


    [WebMethod]
    public bool CargarPasaje(int id, DateTime fecha, int trans)
    {
        BD_PasajeUrbano bdPasaje = new BD_PasajeUrbano();
        BD_TransporteUrbano bdTransporte = new BD_TransporteUrbano();
        //hago el buscar x id que esta en la bdTransporteUrbano 
        try
        {
            //bdPasaje.Agregar(pas);
            return true;
        }
        catch  
        {
            return false;
        }
    }
}
