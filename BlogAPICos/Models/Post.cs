namespace BlogAPICos.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public List<Comentario> Comentarios { get; set; }
    }
}
