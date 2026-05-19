using Inventario.Application.DTOs.Categoria;
using Inventario.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categorias = await _categoriaService.GetAllAsync();
            if (categorias == null) { return NotFound(); }

            return Ok(categorias);

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoria = await _categoriaService.GetByIdAsync(id);

            if (categoria == null)
            {

                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearCategoriaDTO dto)
        {
            var creado = await _categoriaService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ActualizarCategoriaDTO dto)
        {
            var categoria = await _categoriaService.UpdateAsync(id, dto);

            if (categoria == null)
            {

                return NotFound();
            }

            return Ok(categoria);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exite = await _categoriaService.GetByIdAsync(id);
            if (exite == null) return NotFound();

            await _categoriaService.DeleteAsync(id);
            return NoContent();

        }

    }
}
