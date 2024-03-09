using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using PARCIAL1A.Models;

namespace PARCIAL1A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class autoreslibroController : Controller
    {
        private readonly ParcialContext _parcialContext;
        public autoreslibroController(ParcialContext autoreslibrosController)
        {
            _parcialContext = autoreslibrosController;
        }


        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<autoresLibro> listadoAutoresLibros = _parcialContext.autoresLibro.ToList();
            return Ok(listadoAutoresLibros);
        }


        [HttpPost]
        [Route("Create")]
        public IActionResult CreateLibro(libros libro)
        {

            try
            {
                _parcialContext.libros.Add(libro);
                _parcialContext.SaveChanges();
                return Ok("El libro ha sido creado");

            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Error al crear el libro: {ex.Message}");
            }

        }


        [HttpPut]
        [Route("Update/{id}")]
        public IActionResult ActualizarLibro(int id, libros libroActualizado)
        {


            var libro = _parcialContext.libros.Find(id);
            if (libro == null)
            {
                return NotFound("libro no encontrado");
            }

            libro.Titulo = libroActualizado.Titulo;


            try
            {
                _parcialContext.SaveChanges();
                return Ok("libro fue actualizado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar el libro: {ex.Message}");
            }

        }


        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteLibro(int id)
        {
            var libro = _parcialContext.libros.Find(id);
            if (libro == null)
            {
                return NotFound("libro no encontrado");
            }
            try
            {
                _parcialContext.libros.Remove(libro);
                _parcialContext.SaveChanges();
                return Ok("El libro se ha eliminado correctamnete");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al borra el libro: {ex.Message}");
            }
        }

    }

}
