using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using PARCIAL1A.Models;

namespace PARCIAL1A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class postsController : Controller
    {
        private readonly ParcialContext _parcialContext;
        public postsController(ParcialContext postsController)
        {
            _parcialContext = postsController;
        }


        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<posts> listadoPost = _parcialContext.posts.ToList();
            return Ok(listadoPost);
        }

        

        [HttpPost]
        [Route("Create")]
        public IActionResult CreatePost(posts post)
        {

            try
            {
                _parcialContext.posts.Add(post);
                _parcialContext.SaveChanges();
                return Ok("El post ha sido creado");

            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Error al crear el posts: {ex.Message}");
            }

        }


        [HttpPut]
        [Route("Update/{id}")]
        public IActionResult ActualizarPost(int id, posts postActualizado)
        {


            var post = _parcialContext.posts.Find(id);
            if (post == null)
            {
                return NotFound("autor no encontrado");
            }

            post.Titulo = postActualizado.Titulo;
            post.Contenido = postActualizado.Contenido;
            post.FechaPublicacion = postActualizado.FechaPublicacion;
            post.AutorId = postActualizado.AutorId;


            try
            {
                _parcialContext.SaveChanges();
                return Ok("post fue actualizado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar el post: {ex.Message}");
            }

        }


        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Deletepost(int id)
        {
            var post = _parcialContext.posts.Find(id);
            if (post == null)
            {
                return NotFound("post no encontrado");
            }
            try
            {
                _parcialContext.posts.Remove(post);
                _parcialContext.SaveChanges();
                return Ok("El post se ha eliminado correctamnete");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al borra el post: {ex.Message}");
            }
        }
    }
}
