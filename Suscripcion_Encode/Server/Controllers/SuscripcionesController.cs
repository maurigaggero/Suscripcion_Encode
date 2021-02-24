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
            return await _context.Suscripciones
                .Include(x => x.Suscriptor)
                .OrderByDescending(x => x.FechaAlta).ToListAsync();
        }

        // GET: api/suscripciones/5
        [HttpGet("existe/{tipo}/{numero}")]
        public async Task<ActionResult<Suscripcion>> Get(Suscriptor.TiposDocumento tipo, string numero)
        {
            return await _context.Suscripciones
                .Include(x => x.Suscriptor)
                .FirstAsync(x => x.Suscriptor.NumeroDocumento == numero
                && x.Suscriptor.TipoDocumento == tipo);
        }

        // POST: api/suscripciones
        [HttpPost]
        public async Task<ActionResult> Post(Suscripcion suscripcion)
        {
            suscripcion.FechaAlta = DateTime.Now;
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

        private bool Exists(int id)
        {
            return _context.Suscripciones.Any(e => e.IdAsociacion == id);
        }
    }
}