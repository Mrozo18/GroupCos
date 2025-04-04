using BlogAPICos.Data;
using BlogAPICos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogAPICos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentariosController : ControllerBase
    {
        private readonly BlogContext _context;
        public ComentariosController(BlogContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comentarios = await _context.Comentarios
                .Include(c => c.Usuario)
                .Include(c => c.Post)
                .ToListAsync();

            return Ok(comentarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var comentarios = await _context.Comentarios.FindAsync(id);
            return comentarios == null ? NotFound() : Ok(comentarios);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comentario comentarios)
        {
            _context.Comentarios.Add(comentarios);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = comentarios.ComentarioId }, comentarios);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Comentario comentarios)
        {
            if (id != comentarios.ComentarioId) return BadRequest();
            _context.Entry(comentarios).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null) return NotFound();
            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
