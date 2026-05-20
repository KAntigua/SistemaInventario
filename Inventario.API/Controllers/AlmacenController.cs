using Inventario.Application.DTOs.Almacen;
using Inventario.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlmacenController : ControllerBase
    {
        private readonly IAlmacenService _almacenService;

        public AlmacenController(IAlmacenService almacenService)
        {
            _almacenService = almacenService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var almacenes = await _almacenService.GetAllAsync();
            if (almacenes == null) { return NotFound(); }

            return Ok(almacenes);

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var almacen = await _almacenService.GetByIdAsync(id);

            if (almacen == null)
            {

                return NotFound();
            }

            return Ok(almacen);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearAlmacenDTO dto)
        {
            var creado = await _almacenService
                .CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] ActualizarAlmacenDTO dto)
        {
            var almacen = await _almacenService.UpdateAsync(id, dto);

            if (almacen == null)
            {

                return NotFound();
            }

            return Ok(almacen);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exite = await _almacenService.GetByIdAsync(id);
            if (exite == null) return NotFound();

            await _almacenService.DeleteAsync(id);
            return NoContent();

        }

    }
}
