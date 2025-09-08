using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonitoringMottu.Domain;
using MonitoringMottu.Domain.Entities;
using MonitoringMottu.Infrastructure.Context;

namespace CP2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GaragemController : ControllerBase
    {
        private readonly MonitoringMottuContext _context;

        public GaragemController(MonitoringMottuContext context)
        {
            _context = context;
        }

        // GET: api/Garagem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Garagem>>> GetGaragens()
        {
            var garagens = await _context.Garagens
                .Include(g => g.Motos)
                .ToListAsync();

            return garagens;
        }


        // GET: api/Garagem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Garagem>> GetGaragem(Guid id)
        {
            var garagem = await _context.Garagens.FindAsync(id);

            if (garagem == null)
            {
                return NotFound();
            }

            return garagem;
        }

        // PUT: api/Garagem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGaragem(Guid id, Garagem garagem)
        {
            if (id != garagem.Id)
            {
                return BadRequest();
            }

            _context.Entry(garagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GaragemExists(id))
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

        // POST: api/Garagem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Garagem>> PostGaragem(Garagem garagem)
        {
            _context.Garagens.Add(garagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGaragem", new { id = garagem.Id }, garagem);
        }

        // DELETE: api/Garagem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGaragem(Guid id)
        {
            var garagem = await _context.Garagens.FindAsync(id);
            if (garagem == null)
            {
                return NotFound();
            }

            _context.Garagens.Remove(garagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GaragemExists(Guid id)
        {
            return _context.Garagens.Any(e => e.Id == id);
        }
    }
}
