using Inventario.Application.DTOs.Categoria;
using Inventario.Application.DTOs.Factura;
using Inventario.Application.Services.Implementations;
using Inventario.Application.Services.Interfaces;
using Inventario.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FacturaController : ControllerBase
    {

        private readonly IFacturaService _facturaService;

        public FacturaController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var facturas = await _facturaService.GetAllAsync();
            if (facturas == null) { return NotFound(); }

            return Ok(facturas);

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var factura = await _facturaService.GetByIdAsync(id);

            if (factura == null)
            {

                return NotFound();
            }

            return Ok(factura);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearFacturaDTO dto)
        {
            var creado = await _facturaService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ActualizarFacturaDTO dto)
        {
            var factura = await _facturaService.UpdateAsync(id, dto);

            if (factura == null)
            {

                return NotFound();
            }

            return Ok(factura);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exite = await _facturaService.GetByIdAsync(id);
            if (exite == null) return NotFound();

            await _facturaService.DeleteAsync(id);
            return NoContent();

        }

        [HttpGet("factura-usuario/{id}")]
        public async Task<IActionResult> GetByUsuarioIdAsync(int id)
        {
            var factura = await _facturaService.GetByUsuarioIdAsync(id);

            if (factura == null)
            {

                return NotFound();
            }

            return Ok(factura);
        }

        [HttpGet("factura-estado/{estado}")]
        public async Task<IActionResult> GetByEstadoAsync(EstadoFactura estado)
        {
            var factura = await _facturaService.GetByEstadoAsync(estado);

            if (factura == null)
            {

                return NotFound();
            }

            return Ok(factura);
        }


    }
}
