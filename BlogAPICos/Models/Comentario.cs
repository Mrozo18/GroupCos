namespace BlogAPICos.Models
{
    public class Comentario
    {
        public int ComentarioId { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaComentario { get; set; } = DateTime.Now;
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
