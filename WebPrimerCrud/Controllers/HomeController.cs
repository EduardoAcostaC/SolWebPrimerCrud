using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPrimerCrud.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string cadenaConexion = "server = localhost; database = Generacion22; user = sa; password = Mazinger7.";
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            string query = $"SELECT idAlumno, Nombre, apellidoPaterno, apellidoMaterno, Edad, Correo FROM Alumnos";
            //Objeto clase Adapter
            SqlDataAdapter adapter = new SqlDataAdapter(query, conexion); 
            
            //CAreamos objeto DataTable
            DataTable tabla = new DataTable();

            //Ejecucion del query y almacenamiento en tabla
            adapter.Fill(tabla);


            return View("Index", tabla);
        }

        public ActionResult AbrirConexion()
        {
            string cadenaConexion = "server = localhost; database = Generacion22; user = sa; password = Mazinger7.";

            //Cadena de conexion con WINDOWS AUTHENTICATION
            //string cadenaConexion = "server=localhost;database=Generacion21;Integrated Security=True";


            //Creando objeto de conexion con la cadena de conexion
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            conexion.Open(); //Abrir conexion

            string mensaje = " ";
            if (conexion.State == ConnectionState.Open)
            {
                mensaje = "Conexion establecida";
            } 
            else
            {
                mensaje = "Error al conectarse";
            }

            TempData["conexion"] = mensaje;

            conexion.Close(); //Cerrar conexion


            return RedirectToAction("Index");
        }

        public ActionResult IrFormulario()
        {
            return View("VistaFormulario");
        }

        public ActionResult FormularioPOST(string Nombre, string Paterno, string Materno, int Edad, string Correo)
        {
            //Creamos la cadena de conexion
            string cadenaConexion = "server = localhost; database = Generacion22; user= sa; password = Mazinger7.";

            //Creamos objeto de conexion
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            //Abrimos conexion
            conexion.Open();

            string query = $"INSERT INTO Alumnos (Nombre, apellidoPaterno, apellidoMaterno, Edad, Correo)" +
                $"VALUES ('{Nombre}', '{Paterno}', '{Materno}', {Edad}, '{Correo}');";

            //Creamos objeto de SqlCommand
            SqlCommand comando = new SqlCommand(query, conexion);

            //Ejecutamos el comando
            comando.ExecuteNonQuery(); //insert, update, delete

            //Cerramos conexion
            conexion.Close();

            TempData["mensaje"] = $"El alumno {Nombre} se guardo en la base de datos";

            return RedirectToAction("Index");
        }

        public ActionResult Edicion(int idAlumno)
        {
            //Creamos la cadena de conexion
            string cadenaConexion = "server = localhost; database = Generacion22; user= sa; password = Mazinger7.";

            //Creamos objeto de conexion
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            string query = "SELECT idAlumno, Nombre, apellidoPaterno, apellidoMaterno, Edad, Correo " +
                $" FROM Alumnos WHERE idAlumno = {idAlumno};";

            SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);

            DataTable table = new DataTable();

            adapter.Fill(table);

            DataRow filaAlumno = table.Rows[0];


            conexion.Close();

            return View("VistaEditar", filaAlumno);
        }

        public ActionResult Actualizar(int idAlumno, string Nombre, string Paterno, string Materno, int Edad, string Correo)
        {
            string cadenaConexion = "server = localhost; database = Generacion22; user= sa; password = Mazinger7.";
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            conexion.Open();

            string query = $"UPDATE Alumnos SET Nombre='{Nombre}', apellidoPaterno='{Paterno}', apellidoMaterno='{Materno}', Edad={Edad}, Correo='{Correo}'" +
                $"WHERE idAlumno={idAlumno};";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.ExecuteNonQuery();

            conexion.Close();

            TempData["mensaje"] = $"El alumno con id {idAlumno} ha sido editado correctamente";

            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int idAlumno)
        {
            string cadenaConexion = "server = localhost; database = Generacion22; user= sa; password = Mazinger7.";
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            conexion.Open();

            string query = $"DELETE Alumnos WHERE idAlumno ={idAlumno};";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.ExecuteNonQuery ();

            conexion.Close();

            TempData["mensaje"] = $"El alumno con id {idAlumno} ha sido eliminado correctamente";

            return RedirectToAction("Index");
        }
    }
}