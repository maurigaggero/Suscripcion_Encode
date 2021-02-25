using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Suscripcion_Encode.Server.Controllers;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Suscriptor>> Get(int id)
        {
            var suscriptor =  await _context.Suscriptores.FirstAsync(x => x.IdSuscriptor == id);
            suscriptor.Password = Seguridad.DesEncriptar(suscriptor.Password);
            return suscriptor;
        }

        // GET: api/suscriptores/existe/1/40574217
        [HttpGet("existe/{tipo}/{numero}")]
        public async Task<ActionResult<Suscriptor>> Get(Suscriptor.TiposDocumento tipo, string numero)
        {
            var suscriptor = await _context.Suscriptores
                .FirstAsync(x => x.NumeroDocumento == numero && x.TipoDocumento == tipo);

            suscriptor.Password = Seguridad.DesEncriptar(suscriptor.Password);
            return suscriptor;
        }

        // POST: api/suscriptores
        [HttpPost]
        public async Task<ActionResult> Post(Suscriptor suscriptor)
        {
            if (Exists(suscriptor.TipoDocumento, suscriptor.NumeroDocumento)
            || Exists(suscriptor.NombreUsuario))
            {
                return Conflict();
            }
            else
            {
                suscriptor.Password = Seguridad.Encriptar(suscriptor.Password);
                _context.Suscriptores.Add(suscriptor);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }

        // PUT: api/suscriptores
        [HttpPut]
        public async Task<ActionResult> Put(Suscriptor suscriptor)
        {
            if (Exists(suscriptor.NombreUsuario))
            {
                return Conflict();
            }
            else
            {
                suscriptor.Password = Seguridad.Encriptar(suscriptor.Password);
                _context.Entry(suscriptor).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
        private bool Exists(string usuario)
        {
            return _context.Suscriptores.Any(e => e.NombreUsuario == usuario);
        }

        private bool Exists(Suscriptor.TiposDocumento tipo, string numero)
        {
            return _context.Suscriptores.Any(e => e.NumeroDocumento == numero
                                             && e.TipoDocumento == tipo);
        }
    }
}