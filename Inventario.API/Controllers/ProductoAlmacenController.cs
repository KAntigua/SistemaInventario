using Inventario.Application.DTOs.ProductoAlmacen;
using Inventario.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoAlmacenController : ControllerBase
    {
        private readonly IProductoAlmacenService _productoAlmacenService;

        public ProductoAlmacenController(IProductoAlmacenService productoAlmacenService)
        {
            _productoAlmacenService = productoAlmacenService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productosAlmacen =
                await _productoAlmacenService.GetAllAsync();

            if (productosAlmacen == null)
            {
                return NotFound();
            }

            return Ok(productosAlmacen);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productoAlmacen =
                await _productoAlmacenService.GetByIdAsync(id);

            if (productoAlmacen == null)
            {
                return NotFound();
            }

            return Ok(productoAlmacen);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CrearProductoAlmacenDTO dto)
        {
            var creado = await _productoAlmacenService
                .CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = creado.Id },
                creado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] ActualizarProductoAlmacenDTO dto)
        {
            var productoAlmacen =
                await _productoAlmacenService
                    .UpdateAsync(id, dto);

            if (productoAlmacen == null)
            {
                return NotFound();
            }

            return Ok(productoAlmacen);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existe =
                await _productoAlmacenService.GetByIdAsync(id);

            if (existe == null)
            {
                return NotFound();
            }

            await _productoAlmacenService.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("almacen-id")]
        public async Task<IActionResult> GetByAlmacenIdAsync([FromQuery] int almacenId)
        {
            var productoAlmacen = await _productoAlmacenService.GetByAlmacenIdAsync(almacenId);

            if (productoAlmacen == null)
            {

                return NotFound();
            }

            return Ok(productoAlmacen);
        }

        [HttpGet("almacen-producto")]
        public async Task<IActionResult> GetByProductoYAlmacenAsync([FromQuery] int productoId, [FromQuery] int almacenId)
        {
            var productoAlmacen = await _productoAlmacenService.GetByProductoYAlmacenAsync(productoId,almacenId);

            if (productoAlmacen == null)
            {

                return NotFound();
            }

            return Ok(productoAlmacen);
        }

    }
}
