using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ejemplomvc.Models;
using ejemplomvc.Data;
using System.Linq;
namespace ejemplomvc.Controllers
{
	public class CrudController : Controller
    {

        private readonly Conexion conexion;

        public CrudController(Conexion con)
        {
            conexion = con;
        }

        public IActionResult Index()
        {

            
            List<Usuario> lista = new List<Usuario>();

            foreach (var x in conexion.Usuarios) {
                lista.Add(x);
            }
            ViewData["usuarios"] = lista;
            return View("Crud");
        }
        //este lo utilizo en el ajax
        //CRUD/RegresaUsuarios?pagina=100
        public IActionResult RegresaUsuarios(int pagina)
        {
            int usuarios_por_pagina = 5;
            int num_paginas = conexion.Usuarios.Count() / usuarios_por_pagina;


            if (pagina == 0) {
                pagina = 1;
            }
            pagina--;
            var paginacion = conexion.Usuarios.Skip(pagina * usuarios_por_pagina).Take(usuarios_por_pagina);
            Dictionary<String, Object> paginacion_y_num_paginas = new Dictionary<string, object>();

            paginacion_y_num_paginas.Add("paginacion", paginacion);
            paginacion_y_num_paginas.Add("num_paginas", num_paginas);
            return Json(paginacion_y_num_paginas);
        }



        public IActionResult BorrarUsuario(int id) {

            var id_registro = conexion.Usuarios.Find(id);
            conexion.Remove(id_registro);
            conexion.SaveChanges();
            return Json(id_registro);
        }


        public IActionResult NuevoUsuario(String primer_nombre, String segundo_nombre, String apellido)
        {

            Usuario nuevo_registro  = new Usuario { primer_nombre= primer_nombre, segundo_nombre = segundo_nombre, apellido = apellido };
            conexion.Add(nuevo_registro);
            conexion.SaveChanges();
            return Json(nuevo_registro);
        }

        public IActionResult EditarUsuario(int id, String primer_nombre, String segundo_nombre, String apellido) {
            //aqui tampoco xd
            var id_registro = conexion.Usuarios.Find(id);
            id_registro.primer_nombre = primer_nombre;
            id_registro.segundo_nombre = segundo_nombre;
            id_registro.apellido = apellido;

            //var act_registro = new Usuario() { Id = id, primer_nombre = primer_nombre, segundo_nombre = segundo_nombre, apellido = apellido };
            //Console.WriteLine(act_registro);
            //conexion.Update<Usuario>(act_registro);
            conexion.SaveChanges();

            return Json(id_registro);
        }

        public IActionResult DatosUsuario(int id)
        {
            var id_registro = conexion.Usuarios.Find(id);
            return Json(id_registro);
        }

    }



}

