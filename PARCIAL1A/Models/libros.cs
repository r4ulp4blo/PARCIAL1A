using System.ComponentModel.DataAnnotations;

namespace PARCIAL1A.Models
{
    public class libros
    {
        [Key]
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
    }
}
