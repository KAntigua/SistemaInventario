using Inventario.Application.DTOs.Movimiento;
using Inventario.Application.DTOs.Producto;
using Inventario.Application.Services.Implementations;
using Inventario.Application.Services.Interfaces;
using Inventario.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.API.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoService _movimientoService;

        public MovimientoController(IMovimientoService movimientoService)
        {
            _movimientoService = movimientoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movimientos = await _movimientoService.GetAllAsync();
            if (movimientos == null) { return NotFound(); }

            return Ok(movimientos);

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movimiento = await _movimientoService.GetByIdAsync(id);

            if (movimiento == null)
            {

                return NotFound();
            }

            return Ok(movimiento);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearMovimientoDTO dto)
        {
            var creado = await _movimientoService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exite = await _movimientoService.GetByIdAsync(id);
            if (exite == null) return NotFound();

            await _movimientoService.DeleteAsync(id);
            return NoContent();

        }

        [HttpGet("producto/{id}")]
        public async Task<IActionResult> GetByProductoIdAsync(int id)
        {
            var movimiento = await _movimientoService.GetByProductoIdAsync(id);

            if (movimiento == null)
            {

                return NotFound();
            }

            return Ok(movimiento);
        }


        [HttpGet("usuario/{id}")]
        public async Task<IActionResult> GetByUsuarioIdAsync(int id)
        {
            var movimiento = await _movimientoService.GetByUsuarioIdAsync(id);

            if (movimiento == null)
            {
                return NotFound();
            }

            return Ok(movimiento);
        }

    }
}
