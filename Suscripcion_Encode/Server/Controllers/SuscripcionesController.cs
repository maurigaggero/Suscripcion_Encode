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
    public class SuscripcionesController : ControllerBase
    {
        private readonly DataContext _context;

        public SuscripcionesController(DataContext context)
        {
            _context = context;
        }

        //GET: api/suscripciones
        [HttpGet]
        public async Task<ActionResult<List<Suscripcion>>> Get()
        {
            return await _context.Suscripciones.OrderByDescending(x => x.FechaAlta).ToListAsync();
        }

        // GET: api/suscripciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Suscripcion>> Get(int id)
        {
            return await _context.Suscripciones.FirstAsync(x => x.IdAsociacion == id);
        }


        // POST: api/suscripciones
        [HttpPost]
        public async Task<ActionResult> Post(Suscripcion suscripcion)
        {
            _context.Suscripciones.Add(suscripcion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Exists(suscripcion.IdAsociacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }


        // PUT: api/suscripciones
        [HttpPut]
        public async Task<ActionResult> Put(Suscripcion suscripcion)
        {
            _context.Entry(suscripcion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/suscripciones/5  
        [HttpDelete("{id}")]
        public async Task<ActionResult<Suscripcion>> Delete(int id)
        {
            var suscripcion = await _context.Suscripciones.FindAsync(id);
            if (suscripcion == null)
            {
                return NotFound();
            }

            _context.Suscripciones.Remove(suscripcion);
            await _context.SaveChangesAsync();

            return suscripcion;
        }

        private bool Exists(int id)
        {
            return _context.Suscripciones.Any(e => e.IdAsociacion == id);
        }
    }
}