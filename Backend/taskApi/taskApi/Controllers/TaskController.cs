using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using taskApi.Data;
using taskApi.Models;
using taskApi.Models.DTOs;

namespace taskApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskDbContext _context;
        public TaskController(TaskDbContext context)
        {
            _context = context;
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteTask([FromRoute] int Id)
        {
            var task = await _context.Tasks.FindAsync(Id);
            if (task == null)
            {
                return NotFound(new { message = "Task não encontrada" });
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Produto removido com sucesso" });
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tasks>>> Get()
        {
            return await _context.Tasks.ToListAsync();
        }

        [HttpPost]

        public async Task<ActionResult> Post([FromBody] TaskDTO taskDTO)
        {

            var task = new Tasks
            {
                Categoria = taskDTO.Categoria,
                Nome = taskDTO.Nome,
                Status = taskDTO.Status,
                Detalhes = taskDTO.Detalhes,
            };
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> AtualizarStatus(int id, [FromBody] AttStatusDTO dto)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            task.Status = dto.Status;

            await _context.SaveChangesAsync();
            return NoContent();
        }

    }


}
