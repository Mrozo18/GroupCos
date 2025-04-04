namespace BlogAPICos.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string ContraseñaHash { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public List<Post> Posts { get; set; }
        public List<Comentario> Comentarios { get; set; }
    }
}
