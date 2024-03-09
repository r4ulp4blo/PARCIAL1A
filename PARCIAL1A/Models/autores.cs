namespace PARCIAL1A.Models
{
    public class autores
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        // Otras propiedades del autor
        public ICollection<AutoresLibro> AutoresLibros { get; set; }
    }
}
