using Inventario.Application.DTOs.Proveedor;
using Inventario.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedorController :ControllerBase
    {
        private readonly IProveedorService _proveedorService;

        public ProveedorController(IProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var proveedores = await _proveedorService.GetAllAsync();
            if (proveedores == null) { return NotFound(); }

            return Ok(proveedores);

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var proveedor = await _proveedorService.GetByIdAsync(id);

            if (proveedor == null)
            {

                return NotFound();
            }

            return Ok(proveedor);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearProveedorDTO dto)
        {
            var creado = await _proveedorService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ActualizarProveedorDTO dto)
        {
            var proveedor = await _proveedorService.UpdateAsync(id, dto);

            if (proveedor == null)
            {

                return NotFound();
            }

            return Ok(proveedor);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exite = await _proveedorService.GetByIdAsync(id);
            if (exite == null) return NotFound();

            await _proveedorService.DeleteAsync(id);
            return NoContent();

        }
         


    }
}
