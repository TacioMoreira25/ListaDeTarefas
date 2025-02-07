using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ListaDeTarefas.Data;
using ListaDeTarefas.Models;
using ListaDeTarefas.Dto;

namespace ListaDeTarefas
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaContext _context;

        public TarefaController(TarefaContext context)
        {
            _context = context;
        }

        // GET: api/Tarefa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarefaDto>>> GetTarefas()
        {
            var tarefas = await _context.Tarefas.ToListAsync();

            var tarefaDtos = tarefas.Select(t => new TarefaDto
            {
                Id = t.Id,
                Titulo = t.Titulo,
                Prazo = t.Prazo,
                Concluido = t.Concluido
            }).ToList();

            return tarefaDtos;
        }

        // GET: api/Tarefa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaDto>> GetTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            var tarefaDto = new TarefaDto
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Prazo = tarefa.Prazo,
                Concluido = tarefa.Concluido
            };

            return tarefaDto;
        }

        // PUT: api/Tarefa/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarefa(int id, TarefaDto tarefaDto)
        {
            if (id != tarefaDto.Id)
            {
                return BadRequest();
            }

            var tarefa = new Tarefa
            {
                Id = tarefaDto.Id,
                Titulo = tarefaDto.Titulo,
                Prazo = tarefaDto.Prazo,
                Concluido = tarefaDto.Concluido
            };

            _context.Entry(tarefa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tarefa
        [HttpPost]
        public async Task<ActionResult<TarefaDto>> PostTarefa(TarefaDto tarefaDto)
        {
            var tarefa = new Tarefa
            {
                Titulo = tarefaDto.Titulo,
                Prazo = tarefaDto.Prazo,
                Concluido = tarefaDto.Concluido
            };

            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();

            var createdTarefaDto = new TarefaDto
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Prazo = tarefa.Prazo,
                Concluido = tarefa.Concluido
            };

            return CreatedAtAction("GetTarefa", new { id = createdTarefaDto.Id }, createdTarefaDto);
        }

        // DELETE: api/Tarefa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TarefaExists(int id)
        {
            return _context.Tarefas.Any(e => e.Id == id);
        }
    }
}
