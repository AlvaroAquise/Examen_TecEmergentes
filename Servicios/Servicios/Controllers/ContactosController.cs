using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LN;
using Entities;
namespace Servicios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactosController : Controller
    {
        private readonly IContactosService _contactosService;

        public ContactosController(IContactosService contactosService)
        {
            _contactosService = contactosService;
        }

        [HttpGet("Lista")]
        public async Task<ActionResult<IEnumerable<Contactos>>> GetContactos()
        {
            var contactos = await _contactosService.GetAllContactosAsync();
            return Ok(contactos);
        }

        [HttpGet("Filtrar Id")]
        public async Task<ActionResult<Contactos>> GetContactosById(int id)
        {
            var contactos = await _contactosService.GetContactosByIdAsync(id);

            if (contactos == null)
            {
                return NotFound($"No se encontró un contacto con el ID {id}.");
            }

            return Ok(contactos);
        }

        [HttpPost("Registrar")]
        public async Task<ActionResult<Contactos>> CreateContactos(Contactos contactos)
        {
            if (contactos == null)
            {
                return BadRequest("Datos de Contacto no válidos.");
            }

            var newContactos = await _contactosService.CreateContactosAsync(contactos);

            if (newContactos == null)
            {
                return StatusCode(500, "Error al crear el Contacto.");
            }

            return CreatedAtAction(nameof(GetContactosById), new { id = newContactos.ID }, "Contacto registrado exitosamente.");
        }

        [HttpPut("Actualizar")]
        public async Task<ActionResult<Contactos>> PutContactos(int id, Contactos contactos)
        {
            if (contactos == null)
            {
                return BadRequest("Datos de Contacto no válidos.");
            }

            await _contactosService.PutContactosByIdAsync(id, contactos);

            return Ok("Contacto actualizado exitosamente.");
        }

        [HttpDelete("Eliminar")]
        public async Task<ActionResult<Contactos>> DeleteContactos(int id)
        {
            var contactos = await _contactosService.DeleteContactosByIdAsync(id);
            if (contactos == null)
            {
                return NotFound($"No se encontró un contacto con el ID {id}.");
            }
            return Ok($"El contacto con el ID {id} ha sido eliminado correctamente.");
        }
    }
}
