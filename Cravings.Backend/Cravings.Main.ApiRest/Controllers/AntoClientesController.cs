using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cravings.DataAccess;

namespace Cravings.ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AntoClientesController : ControllerBase
    {
        private readonly CravingsDbContext _context;

        public AntoClientesController(CravingsDbContext context)
        {
            _context = context;
        }

        // GET: api/AntoClientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AntoCliente>>> GetAntoClientes()
        {
            return await _context.AntoClientes.ToListAsync();
        }

        // GET: api/AntoClientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AntoCliente>> GetAntoCliente(int id)
        {
            var antoCliente = await _context.AntoClientes.FindAsync(id);

            if (antoCliente == null)
            {
                return NotFound();
            }

            return antoCliente;
        }

        // PUT: api/AntoClientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAntoCliente(int id, AntoCliente antoCliente)
        {
            if (id != antoCliente.ConsCliente)
            {
                return BadRequest();
            }

            _context.Entry(antoCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AntoClienteExists(id))
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

        // POST: api/AntoClientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AntoCliente>> PostAntoCliente(AntoCliente antoCliente)
        {
            _context.AntoClientes.Add(antoCliente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AntoClienteExists(antoCliente.ConsCliente))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAntoCliente", new { id = antoCliente.ConsCliente }, antoCliente);
        }

        // DELETE: api/AntoClientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AntoCliente>> DeleteAntoCliente(int id)
        {
            var antoCliente = await _context.AntoClientes.FindAsync(id);
            if (antoCliente == null)
            {
                return NotFound();
            }

            _context.AntoClientes.Remove(antoCliente);
            await _context.SaveChangesAsync();

            return antoCliente;
        }

        private bool AntoClienteExists(int id)
        {
            return _context.AntoClientes.Any(e => e.ConsCliente == id);
        }
    }
}
