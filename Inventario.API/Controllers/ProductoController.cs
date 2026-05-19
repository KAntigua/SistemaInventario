using Inventario.Application.DTOs.Producto;
using Inventario.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class ProductoController : ControllerBase
    {

        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _productoService.GetAllAsync();
            if (productos == null) { return NotFound(); }

            return Ok(productos);

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _productoService.GetByIdAsync(id);

            if (producto == null)
            {

                return NotFound();
            }

            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearProductoDTO dto)
        {
            var creado = await _productoService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ActualizarProductoDTO dto)
        {
            var producto = await _productoService.UpdateAsync(id, dto);

            if (producto == null)
            {

                return NotFound();
            }

            return Ok(producto);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exite = await _productoService.GetByIdAsync(id);
            if (exite == null) return NotFound();

            await _productoService.DeleteAsync(id);
            return NoContent();

        }


        [HttpGet("bajo-stock")]
        public async Task<IActionResult> GetProductosBajoStockAsync()
        {
            var producto = await _productoService.GetProductosBajoStockAsync();

            if (producto == null)
            {

                return NotFound();
            }

            return Ok(producto);
        }
    }
}
