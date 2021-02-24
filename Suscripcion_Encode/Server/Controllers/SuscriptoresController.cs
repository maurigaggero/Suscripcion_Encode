using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Suscripcion_Encode.Server.Data;
using Suscripcion_Encode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Vivero.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuscriptoresController : ControllerBase
    {
        private readonly DataContext _context;

        public SuscriptoresController(DataContext context)
        {
            _context = context;
        }

        //GET: api/suscriptores
        [HttpGet]
        public async Task<ActionResult<List<Suscriptor>>> Get()
        {
            return await _context.Suscriptores.OrderBy(x => x.NombreUsuario).ToListAsync();
        }

        // GET: api/suscriptores/existe/1/40574217
        [HttpGet("existe/{tipo}/{numero}")]
        public async Task<ActionResult<Suscriptor>> Get(Suscriptor.TiposDocumento tipo, string numero)
        {
            return await _context.Suscriptores
                .FirstAsync(x => x.NumeroDocumento == numero && x.TipoDocumento == tipo);
        }

        // POST: api/suscriptores
        [HttpPost]
        public async Task<ActionResult> Post(Suscriptor suscriptor)
        {
            if (Exists(suscriptor.TipoDocumento, suscriptor.NumeroDocumento))
            {
                return Conflict();
            }
            else
            {
                _context.Suscriptores.Add(suscriptor);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }

        // PUT: api/suscriptores
        [HttpPut]
        public async Task<ActionResult> Put(Suscriptor suscriptor)
        {
            _context.Entry(suscriptor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/suscriptores/5  
        [HttpDelete("{id}")]
        public async Task<ActionResult<Suscriptor>> Delete(int id)
        {
            var suscriptor = await _context.Suscriptores.FindAsync(id);
            if (suscriptor == null)
            {
                return NotFound();
            }

            _context.Suscriptores.Remove(suscriptor);
            await _context.SaveChangesAsync();

            return suscriptor;
        }

        private bool Exists(Suscriptor.TiposDocumento tipo, string numero)
        {
            return _context.Suscriptores.Any(e => e.NumeroDocumento == numero
                                             && e.TipoDocumento == tipo);
        }
    }
}