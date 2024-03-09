using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using PARCIAL1A.Models;

namespace PARCIAL1A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class autoresController : Controller
    {
        private readonly ParcialContext _parcialContext;
        public autoresController(ParcialContext autoresController)
        {
            _parcialContext = autoresController;
        }

        /// Metodo para retornar todos los autores

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<autores> listadoAutores = _parcialContext.autores.ToList();
            return Ok(listadoAutores);
        }

        /// Metodo crear autor

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateAutor(autores autor)
        {

            try
            {
                _parcialContext.autores.Add(autor);
                _parcialContext.SaveChanges();
                return Ok("El autor ha sido creado");

            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Error al crear el autor: {ex.Message}");
            }

        }

        /// Metodo actualizar autor

        [HttpPut]
        [Route("Update/{id}")]
        public IActionResult ActualizarAutor(int id, autores autorActualizado)
        {


            var autor = _parcialContext.autores.Find(id);
            if (autor == null)
            {
                return NotFound("cliente no encontrado");
            }

            autor.Nombre = autorActualizado.Nombre;
            

            try
            {
                _parcialContext.SaveChanges();
                return Ok("autor fue actualizado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar el autor: {ex.Message}");
            }

        }

        /// Metodo actualizar autor

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteAutor(int id)
        {
            var autor = _parcialContext.autores.Find(id);
            if (autor == null)
            {
                return NotFound("autor no encontrado");
            }
            try
            {
                _parcialContext.autores.Remove(autor);
                _parcialContext.SaveChanges();
                return Ok("El autor se ha eliminado correctamnete");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al borra el autor: {ex.Message}");
            }
        }
    }
}
